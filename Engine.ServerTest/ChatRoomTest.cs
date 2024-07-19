

using Engine.Server;

namespace Engine.ServerTest;

    public class ChatRoomTest
    {

         private Channel _rabbitMqChannel = new RabbitMqChannel();
         private Repository _repository = new DummyRepository();

         [Fact]
         public void CreateChatRoomTest()
         {
             var ChatRoom = new ChatRoom( _rabbitMqChannel,_repository);
             ChatRoom.Receive();
             Assert.Equal("Hello", _repository.Load().FirstOrDefault().content);
         }


    }
