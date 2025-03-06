using Mapster;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Common.Mappings;

public class UserDtoMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>()
            .Map(dest => dest, src => src)
            .TwoWays();
    }
}