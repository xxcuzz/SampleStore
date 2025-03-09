using ErrorOr;
using MediatR;

using SampleStore.Application.Collections.Common;

namespace SampleStore.Application.Collections.Queries.GetCollectionByName;

public record GetCollectionWithArticlesQuery(string Name)
    : IRequest<ErrorOr<CollectionResult>>;