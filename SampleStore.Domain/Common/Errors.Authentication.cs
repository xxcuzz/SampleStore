using ErrorOr;

namespace SampleStore.Domain.Common;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error WrongEmailOrPassword () => Error.Validation(
            code: "auth.wrong_email_or_password",
            description: "Incorrect Email or password");
    }
}