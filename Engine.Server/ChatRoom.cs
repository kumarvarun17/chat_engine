using System.Reflection.Metadata;

namespace Engine.Server
{
    public class ChatRoom : IObservable<ChatMessage>
    {
        private readonly string name;
        private readonly List<IObserver<ChatMessage>> users;
        private readonly List<ChatMessage> messages;

        public ChatRoom(string name, List<IObserver<ChatMessage>> users)
        {
            if(users.Count < 2) throw new ArgumentException("Chat room must have at least 2 users");
            this.name = name;
            this.users = users;
        }

        private void AddUser(IObserver<ChatMessage> chatUser) => users.Add(chatUser);

        public IDisposable Subscribe(IObserver<ChatMessage> observer)
        {
            AddUser(observer);
            return new Unsubscriber(users, observer);
        }

        public void Send(ChatMessage chatMessage)
        {
            users.ForEach(user => user.OnNext(chatMessage));
        }
    }

    internal class Unsubscriber : IDisposable
    {
        private List<IObserver<ChatMessage>> users;
        private IObserver<ChatMessage> observer;

        public Unsubscriber(List<IObserver<ChatMessage>> users, IObserver<ChatMessage> observer)
        {
            this.users = users;
            this.observer = observer;
        }

        public void Dispose() => users.Remove(observer);
    }

    public record ChatMessage(object content, DateTime dateTime);
}