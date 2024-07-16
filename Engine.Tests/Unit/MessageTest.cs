
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
        public static EventHub eventHub = new TestEventHub();
        public static ChatRoom chatroom_party1_party2 = new ChatRoom(party1, party2);
        [Fact]
        public void SendMessage()
        {
            var chatRoom = new ChatRoom(eventHub, party1,party2);
            chatRoom.Send(party1, new ChatMessage("Hi", DateTime.Now));
            Assert.Equal(1,party2.messages.Count);
            chatRoom.Send(party2, new ChatMessage("how are you", DateTime.Now));
            Assert.Equal(1, party1.messages.Count);
            // UserData.user2.Send(UserData.user1, new ChatMessage("How are you?",DateTime.Now));
            // Assert.Equal(1, UserData.user1.messages.Count);
        }
        [Fact]
        public void EventHubTest()
        { 
           party1.Send(party2,new ChatMessage("Hi",DateTime.Now));
            Assert.Equal(1,party2.messages.Count);
        }

    }
}
