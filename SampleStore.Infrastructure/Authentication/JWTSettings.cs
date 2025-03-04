namespace SampleStore.Infrastructure.Authentication;

public class JWTSettings
{
    public const string SECTION = "JWTSettings";
    
    public string Secret { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public int ExpirationInMinutes { get; init; }
}