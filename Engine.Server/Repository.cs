namespace Engine.Server
{
    public interface Repository
    {
        public void Save(ChatMessage message);
        public List<ChatMessage> Load();
    }
}