using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail
{
    public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestsDetailDto>
    {
        ILeaveRequestRepository _leaveRequestRepository;
        IMapper _mapper;

        public GetLeaveRequestDetailQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            this._leaveRequestRepository = leaveRequestRepository;
            this._mapper = mapper;
        }
        public async Task<LeaveRequestsDetailDto> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
            return _mapper.Map<LeaveRequestsDetailDto>(leaveRequest);
        }
    }
}
