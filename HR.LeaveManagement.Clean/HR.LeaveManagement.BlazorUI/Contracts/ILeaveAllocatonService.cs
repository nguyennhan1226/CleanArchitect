using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Contracts
{
    public interface ILeaveAllocatonService
    {
        Task<Response<Guid>> CreateLeaveAllocation(int leaveTypeId);
    }
}
