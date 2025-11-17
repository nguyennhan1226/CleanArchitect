using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validatate incoming data
            var validator = new CreateLeaveTypeCommandValidatior(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                throw new Exceptions.BadRequestException("Invalid Leave Type", validationResult);
            }

            // Convert to domain entity object
            var leaveTypeEntity = _mapper.Map<Domain.LeaveType>(request);

            // Add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeEntity);

            // Return record id
            return leaveTypeEntity.Id;
        }
    }
}
