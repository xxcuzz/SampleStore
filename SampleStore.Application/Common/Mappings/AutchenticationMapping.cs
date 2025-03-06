using Mapster;
using SampleStore.Application.Authentication.Common;

namespace SampleStore.Application.Common.Mappings;

public class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.UserDto)
            .TwoWays();
    }
}