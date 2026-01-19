using AutoHub.Application.Interfaces;
using AutoHub.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace AutoHub.Application.Services
{
    public class AuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Employee?> ValidateUserAsync(string email, string password)
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();

            var user = employees.FirstOrDefault(e => e.Email == email);

            if (user == null)
                return null;

            if (!PasswordHasher.Verify(password, user.PasswordHash))
                return null;

            return user;
        }
    }
}
