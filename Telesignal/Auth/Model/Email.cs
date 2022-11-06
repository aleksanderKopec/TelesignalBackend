using Microsoft.AspNetCore.Identity;

namespace Telesignal.Auth.Model;

public class Email
{

    public Email(string hash, string domain, string prefix) {
        Hash = hash;
        Domain = domain;
        Prefix = prefix;
    }
    public string Hash { get; set; }
    public string Domain { get; set; }
    public string Prefix { get; set; }

    public Email Parse(string emailString, IPasswordHasher<Email> emailHasher) {
        var domain = emailString[emailString.IndexOf("@", StringComparison.Ordinal)..];
        var prefix = emailString[..3];
        var hash = emailHasher.HashPassword(null, emailString);
        return new Email(hash, domain, prefix);
    }
}
