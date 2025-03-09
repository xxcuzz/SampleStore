using Mapster;

using SampleStore.Application.Articles.Commands.CreateArticle;
using SampleStore.Application.RequestModels.Article;

namespace SampleStore.API.Common.Mapping;

public class ArticleMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateArticleRequest, CreateArticleCommand>()
            .Map(dest => dest, src => src);
    }
}