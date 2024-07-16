
using Engine.Chat;
using Engine.Users;

namespace Engine
{
    public interface EventHub
    {
        void Subscribe(Party user);
        void Publish(Party sender,Party receiver, ChatMessage message,Guid? chatRoomId);
        void Unsubscribe(Party user);


    }
}
