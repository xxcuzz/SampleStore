using FluentValidation;

namespace SampleStore.Application.Articles.Commands.CreateArticle;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(x=>x.CollectionIds)
            .NotNull().WithMessage("CollectionIds cannot be null.")
            .Must(ids => ids.Count != 0).WithMessage("CollectionIds must contain at least one item.");
    }
}