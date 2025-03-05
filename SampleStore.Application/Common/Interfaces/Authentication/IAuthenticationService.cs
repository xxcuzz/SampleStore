using ErrorOr;
using SampleStore.Application.Models;

namespace SampleStore.Application.Common.Interfaces.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResponse> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResponse> Login(string email, string password);
}