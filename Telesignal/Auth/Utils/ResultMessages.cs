namespace Telesignal.Auth.Utils;

internal static class LoginResultMessages
{
    internal const string Success = "Successfully logged in.";
    internal const string Failure = "Failed to log in.";
    internal const string UserDoesNotExist = "User with specified username does not exist";
    internal const string InvalidPassword = "User with specified username does not exist";
}

internal static class RegisterResultMessages
{
    internal const string Success = "Successfully registered an user.";
    internal const string Failure = "Failed to registered an user.";
    internal const string PasswordMismatch = "Given passwords do not match.";
    internal const string UserAlreadyExists = "User with this username already exists";
}
