using ErrorOr;
using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SampleStore.Application.Articles.Commands.CreateArticle;
using SampleStore.Application.Articles.Common;
using SampleStore.Application.Articles.Queries.GetArticleByName;
using SampleStore.Application.RequestModels.Article;

namespace SampleStore.API.Controllers;

[Route("[controller]")]
[AllowAnonymous]
public class ArticlesController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    
    public ArticlesController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetArticleByName(string name)
    {
        var query = new GetArticleByNameQuery(name);
        ErrorOr<ArticleResult> articleResult = await _mediator.Send(query);
        
        return articleResult.Match(
            articleResult => Ok(_mapper.Map<ArticleResponse>(articleResult)),
            errors => Problem(errors));
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateArticle(CreateArticleRequest request)
    {
        var command = new CreateArticleCommand(request.Name,request.Price, request.CollectionIds);
        
        var createArticleResult = await _mediator.Send(command);
        return createArticleResult.Match(
            createArticleResult => Ok(_mapper.Map<ArticleResponse>(createArticleResult)),
            errors => Problem(errors));
    }
}