
using Engine.Users;

namespace Engine
{
    public  interface EventHub
    {
        void Subscribe(User user);
        void Publish(ChatMessage message, User to);
        void Unsubscribe(User user);
    }
}
