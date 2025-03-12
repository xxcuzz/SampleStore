using Mapster;
using SampleStore.Application.Categories.Common;
using SampleStore.Application.Models.DTO;

namespace SampleStore.Application.Common.Mappings;

public class CategoryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CategoryResult, CategoryResponse>()
            .Map(dest => dest, src => src.CategoryDto);

        config.NewConfig<CategoryResponse, CategoryResult>()
            .Map(dest => dest.CategoryDto, src => src);

        config.NewConfig<CategoryDtoSlim, CategoryResult>()
            .Map(dest => dest.CategoryDto, src => src);
        
        config.NewConfig<CategoryResult, CategoryDtoSlim>()
            .Map(dest => dest, src => src.CategoryDto);
    }
}
