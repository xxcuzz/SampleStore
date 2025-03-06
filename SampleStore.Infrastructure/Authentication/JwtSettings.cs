namespace SampleStore.Infrastructure.Authentication;

public class JwtSettings
{
    public const string Section = "JwtSettings";
    
    public string Secret { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public int ExpirationInMinutes { get; init; }
}