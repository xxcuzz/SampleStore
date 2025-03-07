using FluentValidation;

namespace SampleStore.Application.Articles.Queries.GetArticleByName;

public class GetArticleByNameQueryValidator: AbstractValidator<GetArticleByNameQuery>
{
    public GetArticleByNameQueryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.");
    }
}