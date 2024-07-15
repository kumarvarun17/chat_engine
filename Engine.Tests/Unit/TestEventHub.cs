using Engine.Chat;
using Engine.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Tests.Unit
{
    internal class TestEventHub : EventHub
    {
        List<User> users =[];
        public List<(ChatMessage,ChatRoom)> messageQueue = [];
        public void Publish(ChatMessage message, ChatRoom chatRoom,User sender)
        {
            messageQueue.Add((message, chatRoom));
            chatRoom._users.ForEach(u=> { if (u.Id != sender.Id) u.Recieve(message); });
        }

        public void Subscribe(User user) => users.Add(user);

        public void Unsubscribe(User user) => users.Remove(user);
    }
}
