using Telesignal.Common.Interfaces;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth.Model;

public class Email : ISaveable<Email, DatabaseModel.Email>
{

    public Email(string hash, string domain, string prefix) {
        Hash = hash;
        Domain = domain;
        Prefix = prefix;
    }
    public string Hash { get; set; }
    public string Domain { get; set; }
    public string Prefix { get; set; }

    public DatabaseModel.Email ToModel() {
        return new DatabaseModel.Email {
            Hash = Hash,
            Domain = Domain,
            Prefix = Prefix
        };
    }

    public static Email FromModel(DatabaseModel.Email model) {
        return new Email(domain: model.Domain, hash: model.Hash, prefix: model.Prefix);
    }


    public static Email Parse(string emailString, string emailHash) {
        var domain = emailString[emailString.IndexOf("@", StringComparison.Ordinal)..];
        var prefix = emailString[..3];
        return new Email(emailHash, domain, prefix);
    }
}
