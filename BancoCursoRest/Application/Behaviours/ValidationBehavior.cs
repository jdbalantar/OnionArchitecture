using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                    throw new ValidatationException(failures);
            }

            return await next();
        }
    }
}
