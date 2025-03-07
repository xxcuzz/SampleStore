using ErrorOr;

namespace SampleStore.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error EmailAlreadyExists (string email) => Error.Conflict(
            code: "user.duplicate_email",
            description: $"Email '{email}' already exists");
    }
}