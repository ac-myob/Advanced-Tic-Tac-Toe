using AdvTicTacToe.Game.Business.Model;

namespace AdvTicTacToe.Game.Business.Controller.GameSetup;

public interface IGameSetup
{
    public GameState GetNewGameState();
}