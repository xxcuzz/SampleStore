namespace SampleStore.Application.Models.DTO;

public record CategoryDtoSlim(Guid Id, string Name, Guid? ParentId);
