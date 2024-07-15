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
        List<User> users =new List<User>();
        public List<(ChatMessage,User)> messageQueue = new List<(ChatMessage, User)>();
        public void Publish(ChatMessage message, User to)
        {
            messageQueue.Add((message, to));
            to.Recieve(message);
        }

        public void Subscribe(User user) => users.Add(user);

        public void Unsubscribe(User user) => users.Remove(user);
    }
}
