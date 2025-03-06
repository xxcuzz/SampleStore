namespace SampleStore.Domain.Entities;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string FirstName { get; set; } = null!;
    public required string LastName { get; set; } = null!;
    public required string Email { get; set; } = null!;
    public required string Password { get; set; } = null!;
}