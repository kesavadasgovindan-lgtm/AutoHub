using AutoHub.Application.Interfaces;
using AutoHub.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoHub.Application.Services
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _unitOfWork.Employees.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Employees.GetByIdAsync(id);
        }

        public async Task CreateAsync(Employee employee)
        {
            employee.PasswordHash = PasswordHasher.Hash(employee.PasswordHash);
            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeactivateAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null) return;

            employee.IsActive = false;
            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
