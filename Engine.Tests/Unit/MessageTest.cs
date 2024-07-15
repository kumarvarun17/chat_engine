
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Diagnostics;
using System.Reflection.Metadata;
using Engine.Tests.Unit;
using Xunit;
using Engine.Users;

namespace Engine.Tests.Unit
{
    public class MessageTest
    {
        [Fact]
        public void SendMessage()
        {
            UserData.user1.Send(UserData.user2, new ChatMessage("Hi"));
            Assert.Equal(1,UserData.user2.messages.Count);
        }


    }
}
