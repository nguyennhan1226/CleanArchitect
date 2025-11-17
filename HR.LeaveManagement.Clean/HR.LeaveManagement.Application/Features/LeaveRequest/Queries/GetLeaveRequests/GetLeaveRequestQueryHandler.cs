using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests
{
    public class GetLeaveRequestQueryHandler : IRequestHandler<GetLeaveRequestQuery, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;
        private readonly IUserService _userService;
        public GetLeaveRequestQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IAppLogger<GetLeaveTypesQueryHandler> logger, IUserService userService)
        {
            this._leaveRequestRepository = leaveRequestRepository;
            this._mapper = mapper;
            this._logger = logger;
            this._userService = userService;
        }
        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestQuery request, CancellationToken cancellationToken)
        {
            // Query data from database
            var leaveRequests = new List<Domain.LeaveRequest>();
            var requests = new List<LeaveRequestDto>();
            if (request.IsLoggedInUser)
            {
                var userId = _userService.UserId;
                leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails(userId);
                var employee = await _userService.GetEmployee(userId);
                requests = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
                foreach(var rq in requests)
                {
                    rq.Employee = employee;
                }

            }
            else
            {
                leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
                requests = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
                foreach (var rq in requests)
                {
                    var employee = await _userService.GetEmployee(rq.RequestingEmployeeId);
                    rq.Employee = employee;
                }

            }
            
                                
            return requests;
        }
    }
}
