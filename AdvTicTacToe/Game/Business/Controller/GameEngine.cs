using AdvTicTacToe.Game.Business.Controller.GameBoard;
using AdvTicTacToe.Game.Business.Controller.GameResource.Deserializer;
using AdvTicTacToe.Game.Business.Controller.GameResource.Serializer;
using AdvTicTacToe.Game.Business.Controller.GameSetup;
using AdvTicTacToe.Game.Business.Model;
using AdvTicTacToe.Game.Business.View.IO;
using AdvTicTacToe.Game.Exceptions;
using AdvTicTacToe.Game.Variables;

namespace AdvTicTacToe.Game.Business.Controller;

public class GameEngine
{
    private GameState _gameState = new();
    private readonly Query _query;
    private readonly IWriter _writer;
    private readonly IGameSetup _gameSetup;
    private readonly IGameSerializer _gameSerializer;
    private readonly IGameDeserializer _gameDeserializer;

    public GameEngine(IReader reader, IWriter writer, IGameSetup gameSetup, IGameSerializer gameSerializer, IGameDeserializer gameDeserializer)
    {
        _query = new Query(reader, writer);
        _writer = writer;
        _gameSetup = gameSetup;
        _gameSerializer = gameSerializer;
        _gameDeserializer = gameDeserializer;
    }
    
    public GameState Run()
    {
        _setUpGame();
        while (_gameState.CurrentRound <= _gameState.TotalRounds)
        {
            _playRound();
            _displayRoundInfo();
            _resetRound();
            ++_gameState.CurrentRound;
        }
        _displayWinner();
        
        return _gameState;
    }

    private void _setUpGame()
    {
        _writer.Write(Messages.LoadGameFile);
        if (_query.GetString(Constants.YesOrNoRegex) == Constants.No)
            _gameState = _gameSetup.GetNewGameState();
        else
        {
            _writer.Write(Messages.LoadGameFilename);
            var filename = _query.GetString(Constants.AnyOneOrMoreCharRegex);
            _gameState = _gameDeserializer.FromFile(filename);
        }
    }

    private void _playRound()
    {
        do
        {
            _displayRoundInfo();
            _runPlayerTurn();
        } while (!_hasSatisfiedEndGameCondition());
    }
    
    private void _displayRoundInfo()
    {
        _writer.Write(GameInfo.GetInfo(_gameState));
        _writer.Write(BoardDisplay.GetString(_gameState.Board));
        _writer.Write("\n");
    }

    private void _runPlayerTurn()
    {
        try
        {
            _runPlayerMove();
        }
        catch (PlayerQuitException)
        {
            _saveGame();
        }
    }

    private void _runPlayerMove()
    {
        _gameState.CurrentPlayer.Move.PlayerSetTile(_gameState);

        if (BoardValidator.HasMatch(_gameState.Board, _gameState.CurrentPlayer.Tile))
            ++_gameState.CurrentPlayer.Points;

        _gameState.CurrentPlayerId = (_gameState.CurrentPlayerId + 1) % _gameState.Players.Count;
    }

    private void _saveGame()
    {
        _writer.Write(Messages.SaveGameFile);
        if (_query.GetString(Constants.YesOrNoRegex) == Constants.Yes)
        {
            _writer.Write(Messages.SaveGameFilename);
            _gameSerializer.ToFile(_gameState,_query.GetString(Constants.AnyOneOrMoreCharRegex));
        }
        Environment.Exit(0);
    }

    private bool _hasSatisfiedEndGameCondition()
    {
        return
            !BoardValidator.HasTile(_gameState.Board, _gameState.BlankTile) ||
            BoardValidator.HasMatch(_gameState.Board, Constants.P1Tile) ||
            BoardValidator.HasMatch(_gameState.Board, Constants.P2Tile);
    }
    
    private void _resetRound()
    {
        BoardModifier.Populate(_gameState.Board, Constants.BlankTile);
        _gameState.CurrentPlayerId = _gameState.Players.First().Id;
    }

    private void _displayWinner()
    {
        _writer.Write(_gameState.Winner != null ? Messages.GetWinner(_gameState.Winner) : Messages.GameDraw);
    }
}