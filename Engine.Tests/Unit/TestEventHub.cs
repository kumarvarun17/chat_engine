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
        List<Party> users =[];
        public List<(ChatMessage,ChatRoom)> messageQueue = [];
    
        public void Subscribe(Party user) => users.Add(user);

        public void Unsubscribe(Party user) => users.Remove(user);

        public void Publish(Party sender, Party receiver, ChatMessage message,Guid? chatRoomId)
        {
            if (chatRoomId == null) chatRoomId = new ChatRoom(sender, receiver).Id;

            ChatRepository.records.Add(new ChatRecord(chatRoomId, message, sender, receiver));
            receiver.UpdateChatRoom(chatRoomId);
        }
    }
}
