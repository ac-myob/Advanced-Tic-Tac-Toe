using AdvTicTacToe.Game.Business.Model;

namespace AdvTicTacToe.Game.Business.Controller.GameResource.Deserializer;

public interface IGameDeserializer
{
    public GameState FromFile(string filepath);
}