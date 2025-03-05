using ErrorOr;
using MapsterMapper;
using SampleStore.Application.Common.Interfaces.Authentication;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Common;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJWTTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public AuthenticationService(
        IJWTTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public ErrorOr<AuthenticationResponse> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.EmailAlreadyExists(email);
        }

        var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user.Id, email);
        
        var userDto = _mapper.Map<UserDto>(user);
        return new AuthenticationResponse(userDto, token);
    }

    public ErrorOr<AuthenticationResponse> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user || user.Password != password)
        {
            return Errors.Authentication.WrongEmailOrPassword();
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user.Id, email);
        
        var userDto = _mapper.Map<UserDto>(user);
        return new AuthenticationResponse(userDto, token);
    }
}