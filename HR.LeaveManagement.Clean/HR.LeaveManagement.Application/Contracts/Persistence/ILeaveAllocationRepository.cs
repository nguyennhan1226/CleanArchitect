using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);
        Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
        Task AddAllocations(List<LeaveAllocation> allocations);
        Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
        
        /// <summary>
        /// Batch query to get all employee IDs that already have allocations for specific leave type and period
        /// Optimizes N+1 query problem by performing single database query instead of multiple individual checks
        /// </summary>
        /// <param name="employeeIds">List of employee IDs to check</param>
        /// <param name="leaveTypeId">Leave type ID to check for</param>
        /// <param name="period">Allocation period (year) to check for</param>
        /// <returns>List of employee IDs that have existing allocations</returns>
        Task<List<string>> GetEmployeesWithExistingAllocations(List<string> employeeIds, int leaveTypeId, int period);
    }

}
