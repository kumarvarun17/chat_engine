using Engine.Chat;
using Engine.Users;
using System;
using Xunit;
using static Engine.Tests.Unit.UserData;
namespace Engine.Tests.Unit
{
    public class MessageTest
    {
       
        public static ChatRoom chatroom_party1_party2 = new ChatRoom(party1, party2);
        //[Fact]
        //public void SendMessage()
        //{
        //    var chatRoom = new ChatRoom(eventHub, party1,party2);
        //    chatRoom.Send(party1, new ChatMessage("Hi", DateTime.Now));
        //    Assert.Equal(1,party2.messages.Count);
        //    chatRoom.Send(party2, new ChatMessage("how are you", DateTime.Now));
        //    Assert.Equal(1, party1.messages.Count);
        //    // UserData.user2.Send(UserData.user1, new ChatMessage("How are you?",DateTime.Now));
        //    // Assert.Equal(1, UserData.user1.messages.Count);
        //}
        [Fact]
        public void EventHubTest()
        { 
           party1.Send(party2.Id,new ChatMessage("Hi",DateTime.Now));
            Assert.Equal(1,party2.rooms.Count);
             party1.Send(party2.Id, new ChatMessage("Hi", DateTime.Now));
            party1.Send(party2.Id, new ChatMessage("Hello", DateTime.Now));
            Assert.Equal(1, party2.rooms.Count);
            Assert.Equal(1,party1.rooms.Count);
            party2.Send(party1.Id, new ChatMessage("Hi", DateTime.Now));
            party2.Send(party1.Id, new ChatMessage("Hello", DateTime.Now));
            Assert.Equal(1,party1.rooms.Count);
            Assert.Equal(1, party2.rooms.Count);

        }
        



    }

}
