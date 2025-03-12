using MapsterMapper;
using Mediator;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SampleStore.Application.Collections.Commands.CreateCollection;
using SampleStore.Application.Collections.Common;
using SampleStore.Application.Collections.Queries.GetCollections;
using SampleStore.Application.RequestModels.Collection;

namespace SampleStore.API.Controllers;

[Route("[controller]")]
[AllowAnonymous]
public class CollectionsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CollectionsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    // [HttpGet("{name}")]
    // public async Task<IActionResult> GetCollectionWithArticlesByName(string name)
    // {
    //     var query = new GetCollectionWithArticlesQuery(name);
    //     var collectionResult = await _mediator.Send(query);
    //     
    //     return collectionResult.Match(
    //         result => Ok(_mapper.Map<CollectionResponse>(result)),
    //         errors => Problem(errors));
    // }

    [HttpGet]
    public async Task<IActionResult> GetCollections()
    {
        var query = new GetCollectionsQuery();
        var collections = await _mediator.Send(query);
        
        return collections.Match(
            result => Ok(_mapper.Map<List<CollectionResponse>>(result)),
            errors => Problem(errors));
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateCollection(CreateCollectionRequest request)
    {
        var command = new CreateCollectionCommand(request.Name, request.ArticleIds);
        var createCollectionResult = await _mediator.Send(command);
        
        return createCollectionResult.Match(
            result => Ok(_mapper.Map<CollectionResponse>(result)),
            errors => Problem(errors));
    }
}
