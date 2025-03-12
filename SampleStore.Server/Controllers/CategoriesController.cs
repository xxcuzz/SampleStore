using MapsterMapper;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleStore.Application.Categories.Common;
using SampleStore.Application.Categories.Queries.GetCategories;
using SampleStore.Application.Collections.Common;
using SampleStore.Application.Collections.Queries.GetCollections;

namespace SampleStore.API.Controllers;

[Route("[controller]")]
[AllowAnonymous]
public class CategoriesController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CategoriesController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var query = new GetCategoriesQuery();
        var categories = await _mediator.Send(query);

        return categories.Match(
            result => Ok(_mapper.Map<List<CategoryResponse>>(result)),
            errors => Problem(errors));
    }
}
