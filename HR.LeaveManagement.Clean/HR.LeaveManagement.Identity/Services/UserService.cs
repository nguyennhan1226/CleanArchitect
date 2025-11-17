using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId { get => _httpContextAccessor.HttpContext?.User?.FindFirst("uid")?.Value; }

        public async Task<Employee> GetEmployee(string UserId)
        {
          var user = await _userManager.FindByIdAsync(UserId);
            if(user == null)
            {
                throw new NotFoundException($"User with {UserId} not found",UserId);
            }
            return new Employee
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<List<Employee>> GetEmployees()
        {
           var employees = await _userManager.GetUsersInRoleAsync("Employee");
            if(employees == null || employees.Count == 0)
            {
                throw new NotFoundException("No employees found","User list");
            }
            return employees.Select(user => new Employee
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            }).ToList();
        }
    }
}
