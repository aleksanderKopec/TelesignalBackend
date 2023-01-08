using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Common.Interfaces;

public interface ISaveable<T, TModel> where TModel : IDatabaseEntity
{
    TModel ToModel();

    abstract static T FromModel(TModel model);
}
