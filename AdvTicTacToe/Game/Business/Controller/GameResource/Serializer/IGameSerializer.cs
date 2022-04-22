using AdvTicTacToe.Game.Business.Model;

namespace AdvTicTacToe.Game.Business.Controller.GameResource.Serializer;

public interface IGameSerializer
{
    public void ToFile(GameState gameState, string filepath);
}