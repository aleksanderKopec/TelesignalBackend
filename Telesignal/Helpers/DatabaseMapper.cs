using AutoMapper;
using Telesignal.Services.Chat.Components;
using Telesignal.Services.Database.EF.Models;

namespace Telesignal.Helpers
{
    /// <summary>
    /// Used to map database entities to usable chat components.
    /// </summary>
    internal abstract class DatabaseMapper<T1, T2> where T1 : DatabaseEntity where T2 : ChatComponent
    {
        private static MapperConfiguration mapConfig;
        private static Mapper mapper;

        protected DatabaseMapper()
        {
            mapConfig = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            mapper = new Mapper(mapConfig);
        }

        public T1 ToDatabaseEntity(T2 chatComponent)
        {
            return mapper.Map<T1>(chatComponent);
        }

        public T2 FromDatabaseEntity(T1 databaseEntity)
        {
            return mapper.Map<T2>(databaseEntity);
        }

    }

}
