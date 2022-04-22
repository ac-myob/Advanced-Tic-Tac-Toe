using AdvTicTacToe.Game.Business.Controller.GameBoard;
using AdvTicTacToe.Game.Business.Controller.Move;
using AdvTicTacToe.Game.Business.Controller.RNG;
using AdvTicTacToe.Game.Business.Model;
using AdvTicTacToe.Game.Business.View.IO;
using AdvTicTacToe.Game.Variables;

namespace AdvTicTacToe.Game.Business.Controller.GameSetup;

public class GameSetupGeneric : IGameSetup
{
    private readonly GameState _gameState = new();
    private readonly IWriter _writer;
    private readonly IReader _reader;
    private readonly Query _query;
    private readonly HashSet<string> _usedNames = new();

    public GameSetupGeneric(IReader reader, IWriter writer)
    {
        _writer = writer;
        _reader = reader;
        _query = new Query(reader, writer);
    }

    public GameState GetNewGameState()
    {
        _createEmptyBoard();
        _addPlayers();
        _getNumOfRounds();

        return _gameState;
    }

    private void _createEmptyBoard()
    {
        _writer.Write(Messages.GetBoardLength);
        _gameState.Board = new Board(_query.GetInt(Constants.MinBoardLength, invalidInputMsg: Messages.InvalidBoardLength));
        _gameState.BlankTile = Constants.BlankTile;
        
        BoardModifier.Populate(_gameState.Board, _gameState.BlankTile);
    }
    private void _addPlayers()
    {
        _gameState.Players = new List<Player> {new() { Tile = Constants.P1Tile}, new() {Tile = Constants.P2Tile}};

        for (var playerIndex = 0; playerIndex < _gameState.Players.Count; playerIndex++)
        {
            var currentPlayer = _gameState.Players[playerIndex];
            
            currentPlayer.Id = playerIndex;
            currentPlayer.Name = _getPlayerName(playerIndex);
            currentPlayer.Move = _getPlayerType();
        }
    }
    
    private string _getPlayerName(int playerId)
    {
        bool nameAlreadyExists;
        string name;
        _writer.Write(Messages.GetPlayerName(playerId));
        do
        {
            name = _query.GetString(Constants.AnyOneOrMoreCharRegex, Messages.InvalidInputName);
            nameAlreadyExists = _usedNames.Contains(name);
            if (nameAlreadyExists) 
                _writer.Write(Messages.InvalidExistingName);
        } while (nameAlreadyExists);

        _usedNames.Add(name);
        return name;
    }
    
    private IMove _getPlayerType()
    {
        IMove move = null!;
        _writer.Write(Messages.GetPlayerType);
        move = _query.GetString(Constants.PlayerMoveTypeOptionsRegex) switch
        {
            Constants.HumanMoveType => new HumanMove(_reader, _writer),
            Constants.BadCpuMoveType => new BadCpuMove(new NumberGenerator()),
            _ => move
        };
        return move;
    }
    
    private void _getNumOfRounds()
    {
        _writer.Write(Messages.GetNumRounds);
        _gameState.TotalRounds = _query.GetInt(Constants.MinGameRounds, invalidInputMsg: Messages.InvalidGameRounds);
    }
}