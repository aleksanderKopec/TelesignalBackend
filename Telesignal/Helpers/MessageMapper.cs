using DatabaseMessage = Telesignal.Services.Database.EF.Models.Message;
using Telesignal.Services.Chat.Components;
using AutoMapper;

namespace Telesignal.Helpers
{
    /// <summary>
    /// Singleton mapper for user entities.
    /// </summary>
    internal sealed class MessageMapper : DatabaseMapper<DatabaseMessage, Message>
    {
        private MessageMapper() : base() { }

        private static MessageMapper? _instance;

        public static MessageMapper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MessageMapper();
            }
            return _instance;
        }

    }
}
