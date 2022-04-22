using AdvTicTacToe.Game.Business.Controller.GameBoard;
using AdvTicTacToe.Game.Business.Model;
using AdvTicTacToe.Game.Business.View.IO;
using AdvTicTacToe.Game.Exceptions;
using AdvTicTacToe.Game.Variables;
using Newtonsoft.Json;

namespace AdvTicTacToe.Game.Business.Controller.Move;

public class HumanMove : IMove
{
    [JsonProperty]
    private readonly Query _query;
    [JsonProperty]
    private readonly IReader _reader;
    [JsonProperty]
    private readonly IWriter _writer;
    
    public HumanMove(IReader reader, IWriter writer)
    {
        _query = new Query(reader, writer);
        _reader = reader;
        _writer = writer;
    }
    
    public void PlayerSetTile(GameState gameState)
    {
        _writer.Write(Messages.GetPlayMoveOption);
        var playerOption = _query.GetString(Constants.PlayMoveOptionsRegex);

        if (playerOption == Constants.SetTile)
            _setPlayerTile(gameState);
        else
            throw new PlayerQuitException();
    }

    private void _setPlayerTile(GameState gameState)
    {
        int row, col;
        bool moveIsValid;

        do
        {
            _writer.Write(Messages.GetRow);
            row = _query.GetInt(Constants.MinCoord, gameState.Board.Length + 1, Messages.InvalidRow(gameState.Board.Length));
        
            _writer.Write(Messages.GetCol);
            col = _query.GetInt(Constants.MinCoord, gameState.Board.Length + 1, Messages.InvalidCol(gameState.Board.Length));

            moveIsValid = BoardValidator.IsValidMove(gameState.Board, row - 1, col - 1, gameState.BlankTile);
            if (!moveIsValid)
                _writer.Write(Messages.InvalidMove);
            
        } while (!moveIsValid);
        
        BoardModifier.SetTile(gameState.Board, row - 1, col - 1, gameState.CurrentPlayer.Tile);
    } 
}