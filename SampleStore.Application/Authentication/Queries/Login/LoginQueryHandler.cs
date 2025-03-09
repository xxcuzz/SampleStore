using ErrorOr;
using MapsterMapper;
using MediatR;
using SampleStore.Application.Authentication.Common;
using SampleStore.Application.Common.Interfaces.Authentication;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Common.Errors;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(query.Email) is not User user || user.Password != query.Password)
        {
            return Errors.Authentication.WrongEmailOrPassword();
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user.Id, query.Email);
        
        var userDto = _mapper.Map<UserDto>(user);
        return new AuthenticationResult(userDto, token);
    }
}