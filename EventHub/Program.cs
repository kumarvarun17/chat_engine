using Engine.Chat;
using Engine.Users;

namespace Engine.Tests.Unit
{
    public class eventhub
    {
        public static void Main()
        {

        }
    }
   

    public class TestEventHub : EventHub
    {
        List<Party> users = [];
        private static TestEventHub? Instance=null;

        public static TestEventHub GetInstance()
        {
            if (Instance == null)
            {
                Instance = new TestEventHub();
            }
            return Instance;
        }

        private TestEventHub()
        {
           
        }

        public List<(ChatMessage, ChatRoom)> messageQueue = [];

        public void Subscribe(Party user) => users.Add(user);

        public void Unsubscribe(Party user) => users.Remove(user);

        public void Publish(ChatMessage message, Guid chatRoomId)
        {
            ChatRoom room = ChatRoom(chatRoomId);
            room._messages.Add(message);
            room.UpdateChatRoom();
        }

        public ChatRoom ChatRoom(Guid chatRoomId) => ChatRepository.records.First(x => x.Id == chatRoomId);

        public ChatRoom CreateChatRoom(Party sender, Party receiver)
        {
            var room = new ChatRoom(sender, receiver);
            ChatRepository.records.Add(room);
            return room;
        }

        public Party Party(int receiverId) => ChatRepository.parties.FirstOrDefault(x => x.Id == receiverId);
    }

    internal static class ChatRepository
    {
        internal static List<ChatRoom> records = [];
        internal static List<Party> parties = [UserData.party1, UserData.party2];
    }

    public static class UserData
    {
        public static EventHub eventHub = TestEventHub.GetInstance();
        public static Party party1 = new Party(1, eventHub);
        public static Party party2 = new Party(2, eventHub);
    }
}