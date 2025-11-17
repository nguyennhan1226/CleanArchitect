using AutoMapper;
using Blazored.LocalStorage;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        private readonly IMapper _mapper;
        public LeaveRequestService(IClient client, IMapper mapper, ILocalStorageService localStorageService, ILoggerFactory loggerFactory) 
            : base(client, localStorageService, loggerFactory)
        {
            _mapper = mapper;
        }

        public async Task ApproveLeaveRequest(int id, bool approved)
        {
            try
            {
                var request = new ChangeLeaveRequestApprovalCommand()
                {
                    Id = id,
                    Approved = approved
                };
                await _client.UpdateApprovalAsync(request);
            }
            catch (ApiException ex)
            {
                //ConvertApiExceptions(ex);
            }

        }

        public async Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVM leaveRequest)
        {
            try
            {
                var response = new Response<Guid>();
                CreateLeaveRequestCommand createLeaveRequest = _mapper.Map<CreateLeaveRequestCommand>(leaveRequest);

                await _client.LeaveRequestPOSTAsync(createLeaveRequest);
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public Task DeleteLeaveRequest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {

            var leaveRequests = await _client.LeaveRequestAllAsync(isLoggedInUser: false);
            var model = new AdminLeaveRequestViewVM()
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                RejectedRequests = leaveRequests.Count(q => q.Approved == false),
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            return model;

        }

        public async Task<LeaveRequestVM> GetLeaveRequest(int id)
        {
           var leaveRequest = await _client.LeaveRequestGETAsync(id);
           return _mapper.Map<LeaveRequestVM>(leaveRequest);
        }
    }
}
