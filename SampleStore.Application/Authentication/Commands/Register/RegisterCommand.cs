using ErrorOr;
using Mediator;

using SampleStore.Application.Authentication.Common;

namespace SampleStore.Application.Authentication.Commands.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password)
    : IRequest<ErrorOr<AuthenticationResult>>;