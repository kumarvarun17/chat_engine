using Engine.Server;

namespace Engine.ServerTest
{
    public class DummyRepository:Repository
    {
        List<ChatMessage> messages = new List<ChatMessage>();
        public void Save(ChatMessage message)
        {
            messages.Add(message);
        }

        public List<ChatMessage> Load()
        {
            return messages;
        }
    }
}
