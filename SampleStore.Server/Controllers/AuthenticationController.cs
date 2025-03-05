using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using SampleStore.Application.Common.Interfaces.Authentication;
using SampleStore.Application.Models;
using SampleStore.Application.RequestModels.Authentication;

namespace SampleStore.API.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }
    
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResponse> authResult = _authenticationService.Register(request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return authResult.Match(
            authResult=> Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResponse> authResult = _authenticationService.Login(request.Email, request.Password);
        
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}