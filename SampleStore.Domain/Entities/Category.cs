using SampleStore.Domain.Common.Models;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Domain.Entities;

public class Category : Entity<CategoryId>
{
    public string Name { get; private set; }
    public CategoryId? ParentCategoryId { get; private set; }
    
    List<ArticleId>? ArticlesIds { get; set; }

    private Category(CategoryId id, string name, CategoryId? parentCategoryId, List<ArticleId>? articlesIds)
    {
        Id = id;
        Name = name;
        ParentCategoryId = parentCategoryId;
        ArticlesIds = articlesIds ?? [];
    }

    /// <summary>
    /// Creates a new instance of a category with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the category.</param>
    /// <param name="parentCategoryId">The identifier of the parent category. Can be null if the category is a root category.</param>
    /// <param name="articlesIds">The list of article identifiers associated with the category. Can be null if no articles are specified.</param>
    /// <returns>A new instance of <see cref="Category"/>.</returns>
    /// <remarks>
    /// This method automatically generates a unique identifier for the category using <see cref="CategoryId.CreateUnique"/>.
    /// </remarks>
    public static Category Create(string name, CategoryId? parentCategoryId, List<ArticleId>? articlesIds)
    {
        return new Category(CategoryId.CreateUnique(), name, parentCategoryId, articlesIds);
    }
}