namespace SampleStore.Application.RequestModels.Authentication;

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}