using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SampleStore.Application.Collections.Commands.CreateCollection;
using SampleStore.Application.Collections.Common;
using SampleStore.Application.Collections.Queries.GetCollectionByName;
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
    
    [HttpGet("{name}")]
    public async Task<IActionResult> GetCollectionWithArticlesByName(string name)
    {
        var query = new GetCollectionWithArticlesQuery(name);
        ErrorOr<CollectionResult> collectionResult = await _mediator.Send(query);
        
        return collectionResult.Match(
            collectionResult => Ok(_mapper.Map<CollectionResponse>(collectionResult)),
            errors => Problem(errors));
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCollection(CreateCollectionRequest request)
    {
        var command = new CreateCollectionCommand(request.Name, request.ArticleIds);
        ErrorOr<CollectionResult> createCollectionResult = await _mediator.Send(command);
        
        return createCollectionResult.Match(
            createCollectionResult => Ok(_mapper.Map<CollectionResponse>(createCollectionResult)),
            errors => Problem(errors));
    }
}