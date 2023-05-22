using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }

        public NotFoundException(string message, ValidationResult validationResult) : base(message)
        {
            Errors = validationResult.ToDictionary();
        }

        public IDictionary<string, string[]> Errors { get; set; }
    }
}
