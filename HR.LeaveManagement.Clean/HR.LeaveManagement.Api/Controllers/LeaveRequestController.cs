using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveRequestController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get(bool isLoggedInUser = false)
        {
           var leaveRequests = await _mediator.Send(new GetLeaveRequestQuery());
            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestsDetailDto>> Get(int id)
        {
           var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailQuery() { Id = id });
            return Ok(leaveRequest);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestCommand createLeaveRequestCommand)
        {
            var response = await _mediator.Send(createLeaveRequestCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [Route("CancelRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelRequest(CancelLeaveRequestCommand cancelLeaveRequestCommand)
        {
            await _mediator.Send(cancelLeaveRequestCommand);
            return NoContent();
        }

        [HttpPut]
        [Route("updateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateApproval(ChangeLeaveRequestApprovalCommand changeLeaveRequestApprovalCommand)
        {
            await _mediator.Send(changeLeaveRequestApprovalCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }


    }
}
