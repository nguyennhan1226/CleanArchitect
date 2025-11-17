using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalValidator : AbstractValidator<ChangeLeaveRequestApprovalCommand>
    {
        public ChangeLeaveRequestApprovalValidator()
        {
            RuleFor(p => p.Id).NotNull().GreaterThan(0)
                .WithMessage("{PropertyName} must be a valid leave request");
            RuleFor(p => p.Approved).NotNull().WithMessage("Approve status cannot be null");
        }
    }
}
