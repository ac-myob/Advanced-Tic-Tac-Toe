using AdvTicTacToe.Game.Business.Model;

namespace AdvTicTacToe.Game.Business.Controller.Move;

public interface IMove
{
    public void PlayerSetTile(GameState gameState);
}