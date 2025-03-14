using ErrorOr;
using MapsterMapper;
using Mediator;
using SampleStore.Application.Categories.Common;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Domain.Common.Errors;

namespace SampleStore.Application.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, ErrorOr<List<CategoryResult>>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async ValueTask<ErrorOr<List<CategoryResult>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetCategoriesAsync(cancellationToken);
        if (categories.Count == 0)
        {
            return Errors.Category.CategoryListIsEmpty();
        }
        
        var categoryResults = _mapper.Map<List<CategoryResult>>(categories);
        return categoryResults;
    }
}
