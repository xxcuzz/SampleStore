using FluentValidation;

namespace SampleStore.Application.Articles.Queries.GetArticlesByType;

public class GetArticlesByTypeQueryValidator : AbstractValidator<GetArticlesByTypeQuery>
{
    public GetArticlesByTypeQueryValidator()
    {
        RuleFor(x=>x.articleType)
            .IsInEnum()
            .WithMessage("Invalid article type");
    }
}