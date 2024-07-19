namespace Engine.Server;

public interface Channel
{
    public void Send(ChatMessage message);
    public ChatMessage? Receive();
}

public record ChatMessage(object content, Party Receiver, Party Sender);

