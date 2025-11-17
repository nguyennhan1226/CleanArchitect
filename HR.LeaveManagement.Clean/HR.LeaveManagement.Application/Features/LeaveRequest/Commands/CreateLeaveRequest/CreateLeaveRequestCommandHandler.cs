using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Identity;
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

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CreateLeaveRequestCommandHandler> _logger;
        private readonly IUserService _userService;
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository, IEmailSender emailSender, IMapper mapper, IAppLogger<CreateLeaveRequestCommandHandler> logger, IUserService userService)
        {
            this._leaveRequestRepository = leaveRequestRepository;
            this._leaveTypeRepository = leaveTypeRepository;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._emailSender = emailSender;
            this._mapper = mapper;
            this._logger = logger;
            this._userService = userService;
        }
        public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);


            if (validationResult.Errors.Count > 0)
            {
                _logger.LogWarning("Validation failed for leave request. Errors: {ValidationErrors}",
                    string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));
                throw new BadRequestException("Invalid Leave Request", validationResult);
            }

            var employeeId = _userService.UserId;

            var allocation = await _leaveAllocationRepository.GetUserAllocations(employeeId, request.LeaveTypeId);

            if (allocation is null) { 
                validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.LeaveTypeId), "You do not have any allocations for this leave type"));
                throw new BadRequestException("Invalid Leave Request", validationResult);
            }

            int daysRequested = (int)(request.EndDate - request.StartDate).TotalDays;
            if(daysRequested > allocation.NumberOfDays)
            {
                validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.EndDate), "You do not have enough days for this request"));
                throw new BadRequestException("Invalid Leave Request", validationResult);
            }

            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request);
            leaveRequest.RequestingEmployeeId = employeeId;
            leaveRequest.DateRequested = DateTime.Now;
            await _leaveRequestRepository.CreateAsync(leaveRequest);


            try
            {
                var email = new EmailMeassage
                {
                    To = string.Empty,
                    Body = $"Leave request for {leaveRequest.RequestingEmployeeId} from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been updated.",
                    Subject = "Leave Request Created"
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
