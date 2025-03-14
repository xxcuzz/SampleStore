using Mapster;

using SampleStore.Application.Articles.Common;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Common.Mappings;

public class ArticleMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ArticleResult, ArticleResponse>()
            .Map(dest => dest.Id, src => src.ArticleDto.Id)
            .Map(dest => dest.Name, src => src.ArticleDto.Name)
            .Map(dest => dest.OriginalPrice, src => src.ArticleDto.OriginalPrice)
            //.Map(dest => dest.DiscountedPrice, src => src.ArticleDto.DiscountedPrice)
            .TwoWays();
        
        config.NewConfig<Article, ArticleDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.OriginalPrice, src => src.Price.OriginalPrice)
            .Map(dest => dest.DiscountedPrice, src => src.Price.DiscountedPrice)
            .Map(dest => dest.CollectionIds,
                src => src.CollectionIds.Select(id => id.Value).ToList())
            .TwoWays();

        config.NewConfig<ArticleResult, ArticleDtoSlim>()
            .Map(dest => dest, src => src.ArticleDto);

        config.NewConfig<ArticleDtoSlim, ArticleResult>()
            .Map(dest => dest.ArticleDto, src => src);
    }
}
