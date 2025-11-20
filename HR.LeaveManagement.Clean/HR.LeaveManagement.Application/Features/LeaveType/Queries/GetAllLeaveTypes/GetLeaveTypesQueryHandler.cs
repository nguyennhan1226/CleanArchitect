using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            _mapper = mapper ;
           this._leaveTypeRepository = leaveTypeRepository ;
            _logger = logger ;
        }

        public async Task<List<LeaveTypeDto>> solve(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
             _logger.LogInformation("Starting retrieval of all leave types");

                // Support cancellation
                cancellationToken.ThrowIfCancellationRequested();

                // Get data from repository
                var leaveTypes = await _leaveTypeRepository.GetAsync();

                // Map to DTO
                var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

                return data;
           
        }
    }
}
