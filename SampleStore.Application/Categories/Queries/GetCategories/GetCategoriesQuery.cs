using ErrorOr;
using Mediator;
using SampleStore.Application.Categories.Common;

namespace SampleStore.Application.Categories.Queries.GetCategories;

public record GetCategoriesQuery() : IRequest<ErrorOr<List<CategoryResult>>>;
