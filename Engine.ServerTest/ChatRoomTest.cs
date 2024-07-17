

using Engine.Server;

namespace Engine.ServerTest
{
    public class ChatRoomTest
    {
        [Fact]
        public void CreateChatRoomTest()
        {
            Assert.Throws<ArgumentException>(() => new ChatRoom("testChatroom", []));
            var ChatUsers = new List<IObserver<ChatMessage>>() { new Party(), new Party() };
            ChatRoom chatRoom = new ChatRoom("testChatroom", ChatUsers);
            TestObserver observer = new TestObserver();
            chatRoom.Subscribe(observer);
            ChatMessage chatMessage = new ChatMessage("testMessage", DateTime.Now);
            chatRoom.Send(chatMessage);
            Assert.True(observer.messages.Contains(chatMessage));
        }
        [Fact]
        public void AddUser()
        {
            //var ChatUsers = new List<Party>() { new Party(), new Party() };
            //ChatRoom chatRoom = new ChatRoom("testChatroom", ChatUsers);
            //Party chatUser = new Party();
            //chatRoom.AddUser(chatUser);
            //ChatRoomTestVisitor chatRoomVisitor = new ChatRoomTestVisitor();
            //chatRoom.Accept(chatRoomVisitor);
            //ChatUsers.Add(chatUser);
            //Assert.Equal(new ChatRoomDTO("testChatroom", ChatUsers), chatRoomVisitor.chatRoomDTO);
        }

    }
}