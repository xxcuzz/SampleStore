using ErrorOr;
using FluentValidation;
using Mediator;

namespace SampleStore.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async ValueTask<TResponse> Handle(TRequest message, CancellationToken cancellationToken, MessageHandlerDelegate<TRequest, TResponse> next)
    {
        if (_validator is null)
        {
            return await next(message, cancellationToken);
        }
        
        var validationResult = await _validator.ValidateAsync(message, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next(message, cancellationToken);
        }

        var errors = validationResult.Errors.
            ConvertAll(e => Error.Validation(e.PropertyName, e.ErrorMessage));
        
        return (dynamic)errors;
    }
}