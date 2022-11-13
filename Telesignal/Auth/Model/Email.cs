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

    public static Email Parse(string emailString, string emailHash) {
        var domain = emailString[emailString.IndexOf("@", StringComparison.Ordinal)..];
        var prefix = emailString[..3];
        return new Email(emailHash, domain, prefix);
    }
}
