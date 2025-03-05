using ErrorOr;

namespace SampleStore.Domain.Common;

public static partial class Errors
{
    public static class User
    {
        public static Error EmailAlreadyExists (string email) => Error.Conflict(
            code: "user.duplicate_email",
            description: $"Email '{email}' already exists");
    }
}