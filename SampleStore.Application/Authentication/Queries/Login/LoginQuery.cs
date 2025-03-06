using ErrorOr;
using MediatR;
using SampleStore.Application.Authentication.Common;

namespace SampleStore.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password)
    : IRequest<ErrorOr<AuthenticationResult>>;