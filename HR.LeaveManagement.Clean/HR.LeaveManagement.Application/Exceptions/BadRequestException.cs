using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Exceptions
{
    

    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]> ValidationErrors { get; set; }

        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, ValidationResult validationResult) : base(message) {
            this.ValidationErrors = validationResult.ToDictionary();
        }

        
    }
}
