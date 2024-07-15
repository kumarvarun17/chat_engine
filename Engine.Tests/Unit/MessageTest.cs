
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Diagnostics;
using System.Reflection.Metadata;
using Engine.Tests.Unit;
using Xunit;
using Engine.Users;
using System;
using System.Collections.Generic;
using static Engine.Tests.Unit.UserData;
using Engine.Chat;
namespace Engine.Tests.Unit
{
    public class MessageTest
    {
        [Fact]
        public void SendMessage()
        {
            var chatRoom = new ChatRoom(eventHub, user1,user2);
            chatRoom.Send(user1, new ChatMessage("Hi", DateTime.Now));
            Assert.Equal(1,user2.messages.Count);
           // UserData.user2.Send(UserData.user1, new ChatMessage("How are you?",DateTime.Now));
           // Assert.Equal(1, UserData.user1.messages.Count);
        }
        [Fact]
        public void ChatRoomTest()
        { 

        }

    }
}
