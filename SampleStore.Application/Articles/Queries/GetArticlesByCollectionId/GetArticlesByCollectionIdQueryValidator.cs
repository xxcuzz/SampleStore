using FluentValidation;

namespace SampleStore.Application.Articles.Queries.GetArticlesByCollectionId;

public class GetArticlesByCollectionIdQueryValidator : AbstractValidator<GetArticlesByCollectionIdQuery>
{
    public GetArticlesByCollectionIdQueryValidator()
    {
        RuleFor(x => x.CollectionId)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.");
    }
}
