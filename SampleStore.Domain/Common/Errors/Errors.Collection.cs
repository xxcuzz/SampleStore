using ErrorOr;

namespace SampleStore.Domain.Common.Errors;

public static partial class Errors
{
    public static class Collection
    {
        public static Error CollectionNotFound() => Error.NotFound(
            code: "collection.collection_not_found",
            description: "Collection not found");
        
        public static Error CollectionListIsEmpty() => Error.NotFound(
            code: "collection.collections_list_is_empty",
            description: "Collections count is zero");
    }
}