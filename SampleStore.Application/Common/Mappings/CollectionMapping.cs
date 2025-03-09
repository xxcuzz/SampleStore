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
            .Map(dest => dest.Id, src => src.CollectionDto.Id)
            .Map(dest => dest.Name, src => src.CollectionDto.Name)
            .Map(dest => dest.ArticleIds,
                src => src.CollectionDto.ArticleIds)
            .TwoWays();
        
        config.NewConfig<Collection, CollectionDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.ArticleIds, 
                src => src.ArticleIds != null ?
                    src.ArticleIds.Select(id => id.Value).ToList() : new List<Guid>())
            .TwoWays();
    }
}