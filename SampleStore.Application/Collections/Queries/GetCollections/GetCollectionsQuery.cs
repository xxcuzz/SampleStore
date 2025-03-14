using ErrorOr;
using Mediator;
using SampleStore.Application.Collections.Common;

namespace SampleStore.Application.Collections.Queries.GetCollections;

public record GetCollectionsQuery() : IRequest<ErrorOr<List<CollectionResult>>>;
