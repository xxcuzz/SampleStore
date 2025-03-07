using FluentValidation;

namespace SampleStore.Application.Collections.Queries.GetCollectionByName;

public class GetCollectionWithArticlesQueryValidator : AbstractValidator<GetCollectionWithArticlesQuery>
{
    public GetCollectionWithArticlesQueryValidator()
    {
        RuleFor(x=> x.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.");
    }
}