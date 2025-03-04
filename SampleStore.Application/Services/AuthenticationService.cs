using SampleStore.Application.Common.Interfaces.Authentication;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Interfaces;
using SampleStore.Application.Models;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJWTTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResponse Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception($"User with Email:{email} already exists");
        }

        var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user.Id, email);

        return new AuthenticationResponse(, token);
    }

    public AuthenticationResponse Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user || user.Password != password)
        {
            throw new Exception("Email or password is incorrect");
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user.Id, email);
        
        return new AuthenticationResponse(user, token);
    }
}