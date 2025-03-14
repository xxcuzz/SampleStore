using FluentValidation;

namespace SampleStore.Application.Articles.Queries.GetArticlesByCategoryId;

public class GetArticlesByCategoryIdQueryValidator : AbstractValidator<GetArticlesByCategoryIdQuery>
{
    public GetArticlesByCategoryIdQueryValidator()
    {
        RuleFor(q => q.CategoryId)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.");
    }
}
