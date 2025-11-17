using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Models.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _logger;
        public ChangeLeaveRequestApprovalCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository, IEmailSender emailSender, IMapper mapper, IAppLogger<UpdateLeaveRequestCommandHandler> logger)
        {
            this._leaveRequestRepository = leaveRequestRepository;
            this._leaveTypeRepository = leaveTypeRepository;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._emailSender = emailSender;
            this._mapper = mapper;
            this._logger = logger;
        }
        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
           var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(leaveRequest),request.Id);
            }
            leaveRequest.Approved = request.Approved;
            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            // if requested approved , reduce allocation
            if (request.Approved == true)
            {
                
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                var leaveAllocation = await _leaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                leaveAllocation.NumberOfDays -= daysRequested;
                await _leaveAllocationRepository.UpdateAsync(leaveAllocation);
            }



            try
            {
                var email = new EmailMeassage
                {
                    To = string.Empty,
                    Body = $"Leave request for {leaveRequest.RequestingEmployeeId} from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been {(request.Approved ? "approved" : "rejected")}.",
                    Subject = "Leave Request Approval Status Changed"
                };
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
            return Unit.Value;
        }
    }
}
