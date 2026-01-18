using AutoHub.Application.Interfaces;
using AutoHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoHub.Application.Services
{
    public class InvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateInvoiceAsync(
            Invoice invoice,
            List<InvoiceItem> items)
        {
            decimal gross = 0;
            decimal vat = 0;

            foreach (var item in items)
            {
                item.GrossAmount = item.Rate * item.Quantity;

                if (!item.IsLabour)
                {
                    vat += item.GrossAmount * 0.05m;
                }

                item.VatAmount = item.IsLabour ? 0 : item.GrossAmount * 0.05m;
                item.NetAmount = item.GrossAmount + item.VatAmount;

                gross += item.GrossAmount;

                // deduct stock if item
                if (item.ItemId.HasValue)
                {
                    var stockItem = await _unitOfWork.Items.GetByIdAsync(item.ItemId.Value);
                    if (stockItem != null)
                    {
                        stockItem.Stock -= item.Quantity;
                        _unitOfWork.Items.Update(stockItem);
                    }
                }
            }

            invoice.GrossAmount = gross;
            invoice.VatAmount = vat;
            invoice.NetAmount = gross + vat;
            invoice.InvoiceDate = DateTime.Now;

            await _unitOfWork.Invoices.AddAsync(invoice);

            foreach (var item in items)
            {
                item.InvoiceId = invoice.Id;
                await _unitOfWork.InvoiceItems.AddAsync(item);
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
