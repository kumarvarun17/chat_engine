
using Engine.Chat;
using Engine.Users;

namespace Engine
{
    public interface EventHub
    {
        void Subscribe(int id);
        void Publish( ChatMessage message,Guid chatRoomId);
        void Unsubscribe(Party user);
        ChatRoom ChatRoom(Guid chatRoomId);
        ChatRoom CreateChatRoom(Party sender, Party receiver);
        Party Party(int receiverId);
    }
}
