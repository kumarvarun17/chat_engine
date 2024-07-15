
using Engine.Chat;
using Engine.Users;

namespace Engine
{
    public interface EventHub
    {
        void Subscribe(User user);
        void Publish(ChatMessage message, ChatRoom chatRoom, User sender);
        void Unsubscribe(User user);
    }
}
