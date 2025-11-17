using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypesDetail
{
    public class GetLeaveTypesDetailsQueryHandler : IRequestHandler<GetLeaveTypesDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypesDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypesDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // Validate that record exists
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(Domain.LeaveType), request.Id);
            }

            // Convert to DTO
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

            return data;
        }
    }
}
