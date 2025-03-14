using SampleStore.Application.Models.DTO;

namespace SampleStore.Application.Common.Interfaces.Persistence;

public interface ICategoryRepository
{
    Task<List<CategoryDtoSlim>> GetCategoriesAsync(CancellationToken cancellationToken);
}
