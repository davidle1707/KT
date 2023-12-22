using KT.Shared.Context.CMSM.NotificationEntities;

namespace KT.Shared.Context.CMSM
{
    public class NotificationContext : __BaseContext
    {
        public NotificationContext(string connectionString, string dbName)
           : base(connectionString, dbName)
        {
        }

        #region Message

        private GroupCollection<Message> _collectionMessage;
        public GroupCollection<Message> Messages => _collectionMessage ??= new GroupCollection<Message>((name, cache) => CreateCollection<Message>(name, cache), "Msg_");

        private GroupCollection<Message> _deletedMessageCollection;
        public GroupCollection<Message> DeletedMessages => _deletedMessageCollection ??= new GroupCollection<Message>((name, cache) => CreateCollection<Message>(name, cache), "DeletedMsg_");

        #endregion
    }
}
