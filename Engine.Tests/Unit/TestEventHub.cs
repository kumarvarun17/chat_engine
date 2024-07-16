using Engine.Chat;
using Engine.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public void Publish(ChatMessage message,Guid chatRoomId)
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
}
