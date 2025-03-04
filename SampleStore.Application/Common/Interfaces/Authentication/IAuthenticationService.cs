using SampleStore.Application.Models;

namespace SampleStore.Application.Interfaces;

public interface IAuthenticationService
{
    AuthenticationResponse Register(string firstName, string lastName, string email, string password);
    AuthenticationResponse Login(string email, string password);
}