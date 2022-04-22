namespace AdvTicTacToe.Game.Business.View.IO;

public class MockReader : IReader
{
    private readonly Queue<string> _messages = new();

    public MockReader(params object[] messages)
    {
        FeedInput(messages);
    }

    public void FeedInput(params object[] messages)
    {
        foreach (var message in messages) 
            _messages.Enqueue(message.ToString() ?? string.Empty);
    }
    
    public string Read()
    {
        return _messages.Dequeue();
    }
}