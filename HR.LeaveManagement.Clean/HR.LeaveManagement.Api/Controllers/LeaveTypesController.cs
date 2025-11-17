using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypesDetail;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeavteType;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Get all leave types
        /// </summary>
        /// <returns>List of all leave types</returns>
        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());
            return leaveTypes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDetailsDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypesDetailsQuery(id));
            return Ok(leaveType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeCommand createLeaveTypeCommand)
        {
            var response = await _mediator.Send(createLeaveTypeCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveTypeCommand updateLeaveTypeCommand)
        {
            await _mediator.Send(updateLeaveTypeCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand { Id=id});
            return NoContent();
        }
    }
}
