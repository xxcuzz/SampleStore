using ErrorOr;
using MapsterMapper;
using MediatR;
using SampleStore.Application.Authentication.Common;
using SampleStore.Application.Common.Interfaces.Authentication;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Common.Errors;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.EmailAlreadyExists(command.Email);
        }

        var user = new User
        {
            FirstName = command.FirstName, LastName = command.LastName, Email = command.Email,
            Password = command.Password
        };
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user.Id, command.Email);
        
        var userDto = _mapper.Map<UserDto>(user);
        return new AuthenticationResult(userDto, token);
    }
}