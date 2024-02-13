using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using ErrorOr;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse: IErrorOr
    {
        private readonly IValidator<TRequest>? _valodator;

        public ValidationBehavior(IValidator<TRequest>? valodator = null)
        {
            _valodator = valodator;    
        }
        public async Task<TResponse> Handle(TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            if (_valodator == null)
            {
                return await next();
            }
            var validationResult = await _valodator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(er => 
                        Error.Validation(er.PropertyName, er.ErrorMessage))
                .ToList();
            return (dynamic)errors;
        }
    }
}
