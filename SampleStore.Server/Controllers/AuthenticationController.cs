using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using SampleStore.Application.Interfaces;
using SampleStore.Application.Models;
using SampleStore.Application.RequestModels.Authentication;

namespace SampleStore.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
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
        var authResult = _authenticationService.Register(request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = _mapper.Map<AuthenticationResponse>(authResult);
        
        return Ok(response);
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);
        
        var response = _mapper.Map<AuthenticationResponse>(authResult);
        
        return Ok(response);
    }
}