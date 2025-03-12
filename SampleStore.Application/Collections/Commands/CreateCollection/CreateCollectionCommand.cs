using ErrorOr;
using Mediator;

using SampleStore.Application.Collections.Common;

namespace SampleStore.Application.Collections.Commands.CreateCollection;

public record CreateCollectionCommand(string Name, List<Guid>? ArticleIds = null)
    : IRequest<ErrorOr<CollectionResult>>;