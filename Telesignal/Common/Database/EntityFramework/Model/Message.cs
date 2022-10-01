namespace Telesignal.Common.Database.EntityFramework.Model
{
    public class Message : DatabaseEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Author of the message.
        /// </summary>
        public User Author { get; set; }
        /// <summary>
        /// Room in which message has been send.
        /// </summary>
        public Room Room { get; set; }
        /// <summary>
        /// Hashed and encrypted content of message.
        /// </summary>
        public string Content { get; set; }
    }
}
