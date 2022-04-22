using AdvTicTacToe.Game.Business.Model;

namespace AdvTicTacToe.Game.Business.Controller;

public static class GameInfo
{
    public static string GetInfo(GameState gameState)
    {
        var res = $"Round: {gameState.CurrentRound}/{gameState.TotalRounds}\n";
        res = gameState.Players.Aggregate(res, (current, player) => current + $"{player.Name}: {player.Points}\n");
        res += $"Current player: {gameState.CurrentPlayer.Name}\n";

        return res;
    }
}