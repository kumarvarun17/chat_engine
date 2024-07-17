using Engine.Chat;
using Engine.Users;

namespace EventHub.Test
{
    public class eventhub
    {
        public static void Main()
        {

        }
    }
   

    public class TestEventHub : Engine.EventHub
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

        public void Subscribe(int Id) => users.Add(ChatRepository.parties.FirstOrDefault(x => x.Id == Id));

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

    public static class ChatRepository
    {
        public static List<ChatRoom> records = [];
        public static List<Party> parties = [UserData.party1, UserData.party2];
    }
    public static class UserData
    {
        public static Engine.EventHub eventHub = TestEventHub.GetInstance();
        public static Party party2 = new Party(2, eventHub);
        public static Party party1 = new Party(1, eventHub);
    }


}