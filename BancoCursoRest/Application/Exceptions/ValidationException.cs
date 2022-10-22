using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidatationException : Exception
    {
        public ValidatationException() : base("Se han producido uno o más errores de validación")
        {
            Errors = new List<string>();
        }
        
        public List<string> Errors { get; }

        public ValidatationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
                Errors.Add(failure.ErrorMessage);
        }
    }
}
