using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;
        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            this._logger = logger;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validatate incoming data
            var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) {
                _logger.LogWarning("Update Leave Type command validation errors for ID {0}, Name {1}: {2}", 
                    request.Id, request.Name, string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));
                throw new BadRequestException("Invalid Leave Type",validationResult);
            }

            // Convert to domain entity object
            var leaveTypeEntity = _mapper.Map<Domain.LeaveType>(request);

            // Add to database
            await _leaveTypeRepository.UpdateAsync(leaveTypeEntity);

            // Return record id
            return Unit.Value;
        }
    }
}
