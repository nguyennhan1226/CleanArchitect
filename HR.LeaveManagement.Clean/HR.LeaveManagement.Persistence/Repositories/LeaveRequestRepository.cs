using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(DatabaseContext.HrDatabaseContext context) : base(context) { }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests
                .Where(q => !string.IsNullOrEmpty(q.RequestingEmployeeId)) // Filter out entries with null or empty RequestingEmployeeId
                .Include(lr => lr.LeaveType) // Include related LeaveType
                .AsNoTracking()
                .ToListAsync();

            return leaveRequests;
        }   

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
           var leaveRequests = await _context.LeaveRequests
                .Where(lr => lr.RequestingEmployeeId == userId)
                .Include(lr => lr.LeaveType) // Include related LeaveType
                .AsNoTracking()
                .ToListAsync();
            return leaveRequests;
        }

        public Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = _context.LeaveRequests
                .Include(lr => lr.LeaveType) // Include related LeaveType
                .AsNoTracking()
                .FirstOrDefaultAsync(lr => lr.Id == id);
            return leaveRequest;
        }
        // Implement any specific methods for LeaveRequest if needed
    }

}
