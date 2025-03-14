using Mapster;

using SampleStore.Application.Collections.Common;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Common.Mappings;

public class CollectionMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CollectionResult, CollectionResponse>()
            .Map(dest => dest, src => src.CollectionDto);
        config.NewConfig<CollectionResponse, CollectionResult>()
            .Map(dest => dest.CollectionDto, src => src);
        
        config.NewConfig<Collection, CollectionDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name)
            .TwoWays();

        config.NewConfig<CollectionDtoSlim, CollectionResult>()
            .Map(dest => dest.CollectionDto, src => src);
        
        config.NewConfig<CollectionResult, CollectionDtoSlim>()
            .Map(dest => dest, src => src.CollectionDto);
    }
}
