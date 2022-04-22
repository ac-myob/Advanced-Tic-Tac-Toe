namespace AdvTicTacToe.Game.Business.View.IO;

public class ConsoleWriter : IWriter
{
    public void Write(string message)
    {
        Console.Write(message);
    }
}