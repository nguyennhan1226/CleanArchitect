using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationsDetail
{
    public class GetLeaveAllocationDetailsQuery :IRequest <LeaveAllocationDetailDto>
    {
        public int Id { get; set; }
    }
}
