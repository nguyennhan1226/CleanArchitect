using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeavteType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Retrieve existing record
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // Validate record exists
            if (leaveTypeToDelete == null)
            {
                throw new Exceptions.NotFoundException(nameof(Domain.LeaveType), request.Id);
            }

            // Delete record
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            // Return record id
            return Unit.Value;
        }
    }
}
