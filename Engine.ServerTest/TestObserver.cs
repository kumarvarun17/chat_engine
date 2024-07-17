using Engine.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ServerTest
{
    public class TestObserver : IObserver<ChatMessage>
    {
        public List<ChatMessage> messages = new List<ChatMessage>();
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            throw new Exception();
        }

        public void OnNext(ChatMessage message)
        {
            messages.Add(message);
        }
    }
}
