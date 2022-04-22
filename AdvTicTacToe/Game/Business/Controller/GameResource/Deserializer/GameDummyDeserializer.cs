using AdvTicTacToe.Game.Business.Model;

namespace AdvTicTacToe.Game.Business.Controller.GameResource.Deserializer;

public class GameDummyDeserializer : IGameDeserializer
{
    public GameState FromFile(string filepath)
    {
        return new GameState();
    }
}