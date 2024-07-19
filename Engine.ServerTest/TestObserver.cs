using Engine.Server;

namespace Engine.ServerTest;

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

