using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests
{
    public class GetLeaveRequestQuery : IRequest<List<LeaveRequestDto>>
    {
        public bool IsLoggedInUser { get; set; }
        }
}
