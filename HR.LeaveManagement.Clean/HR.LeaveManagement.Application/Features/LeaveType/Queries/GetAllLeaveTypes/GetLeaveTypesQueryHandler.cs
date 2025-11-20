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
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
           this._leaveTypeRepository = leaveTypeRepository ?? throw new ArgumentNullException(nameof(leaveTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<LeaveTypeDto>> handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            try
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
            catch (OperationCanceledException)
            {
                _logger.LogWarning("GetLeaveTypes operation was cancelled");
                throw;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving leave types");
                throw new BadRequestException("Failed to retrieve leave types");
            }
        }
    }
}
