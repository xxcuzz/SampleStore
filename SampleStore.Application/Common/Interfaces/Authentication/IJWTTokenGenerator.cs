namespace SampleStore.Application.Common.Interfaces.Authentication;

public interface IJWTTokenGenerator
{
    string GenerateToken(Guid userId, string email);
}