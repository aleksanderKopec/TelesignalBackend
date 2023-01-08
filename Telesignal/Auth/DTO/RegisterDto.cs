namespace Telesignal.Auth.DTO;

public record RegisterDto(string Email, string Username, string Password, string RepeatPassword, string PublicKey);
