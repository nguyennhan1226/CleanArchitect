using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext context) : base(context) { }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Leave type name cannot be null or empty.", nameof(name));
            }

            // Trim and use case-insensitive comparison
            var trimmedName = name.Trim();
            var exists = await _context.LeaveTypes
                .AnyAsync(q => q.Name.ToLower() == trimmedName.ToLower());

            return !exists;
        }
    }
}
