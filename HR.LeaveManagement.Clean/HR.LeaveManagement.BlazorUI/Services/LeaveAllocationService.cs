using AutoMapper;
using Blazored.LocalStorage;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocatonService
    {
        public LeaveAllocationService(IClient client, ILocalStorageService localStorageService, ILoggerFactory loggerFactory) 
            : base(client, localStorageService, loggerFactory)
        {
        }

        public async Task<Response<Guid>> CreateLeaveAllocation(int leaveTypeId)
        {
            try
            {
                var response = new Response<Guid>();
                CreateLeaveAllocationCommand command = new() { LeaveTypeId = leaveTypeId };
                await _client.LeaveAllocationPOSTAsync(command);
                response.Success = true;
                return response;
            }
            catch (ApiException apiException)
            {
                return ConvertApiExceptions<Guid>(apiException);
            }
        }
    }
}
