using AdvTicTacToe.Game.Business.Controller.GameBoard;
using AdvTicTacToe.Game.Business.Controller.RNG;
using AdvTicTacToe.Game.Business.Model;
using AdvTicTacToe.Game.Variables;
using Newtonsoft.Json;

namespace AdvTicTacToe.Game.Business.Controller.Move;

public class BadCpuMove : IMove
{
    [JsonProperty]
    private readonly INumberGenerator _numberGenerator;
    
    public BadCpuMove(INumberGenerator numberGenerator)
    {
        _numberGenerator = numberGenerator;
    }
    
    public void PlayerSetTile(GameState gameState)
    {
        var posCoords = _getPosCoords(gameState);
        var chosenCoordIdx = _numberGenerator.Next(0, posCoords.Count - 1);
        var (row, col) = posCoords[chosenCoordIdx];
        
        BoardModifier.SetTile(gameState.Board, row, col, gameState.CurrentPlayer.Tile);
    }

    private List<Tuple<int, int>> _getPosCoords(GameState gameState)
    {
        var posCoords = new List<Tuple<int, int>>();
        
        for (var rowIndex = 0; rowIndex < gameState.Board.Length; rowIndex++)
            for (var colIndex = 0; colIndex < gameState.Board.Length; colIndex++)
                if (gameState.Board.Grid[rowIndex, colIndex] == Constants.BlankTile)
                    posCoords.Add(new Tuple<int, int>(rowIndex, colIndex));
        
        return posCoords;
    }
}