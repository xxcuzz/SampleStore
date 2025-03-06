using FluentValidation;

namespace SampleStore.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage("Email is requiredD");
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("Password is requiredD");
    }
}