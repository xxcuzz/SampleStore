namespace SampleStore.Application.Categories.Common;

public record CategoryResponse(Guid Id, string Name, Guid? ParentId);
