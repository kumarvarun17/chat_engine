namespace Engine.Server
{
    public class Party : IObserver<ChatMessage>
    {
        private string _name;
        private Guid _id;

        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(ChatMessage value)
        {
            
        }
    }
}