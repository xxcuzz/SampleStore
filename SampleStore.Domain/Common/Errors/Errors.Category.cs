using ErrorOr;

namespace SampleStore.Domain.Common.Errors;

public static partial class Errors
{
    public static class Category
    {
        public static Error CategoryListIsEmpty() => Error.NotFound(
            code: "category.categories_list_is_empty",
            description: "Categories count is zero");
    }
}
