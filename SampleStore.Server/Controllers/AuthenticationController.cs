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

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.user,
            authResult.token);
        
        return Ok(response);
    }
    
    [HttpPost("Login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);
        
        var response = new AuthenticationResponse(
            authResult.user,
            authResult.token);
        
        return Ok(response);
    }
}