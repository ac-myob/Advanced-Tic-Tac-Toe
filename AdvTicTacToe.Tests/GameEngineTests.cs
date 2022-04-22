using System.Collections.Generic;
using AdvTicTacToe.Game.Business.Controller;
using AdvTicTacToe.Game.Business.Controller.GameResource.Deserializer;
using AdvTicTacToe.Game.Business.Controller.GameResource.Serializer;
using AdvTicTacToe.Game.Business.Controller.GameSetup;
using AdvTicTacToe.Game.Business.View.IO;
using AdvTicTacToe.Game.Variables;
using Xunit;

namespace AdvTicTacToeTests;

public class GameEngineTests
{
    private readonly MockReader _reader;
    private readonly GameEngine _gameEngine;
    
    public GameEngineTests()
    {
        _reader = new MockReader();
        IWriter writer = new DummyWriter();
        IGameSetup gameSetup = new GameSetupGeneric(_reader, writer);
        IGameSerializer gameSerializer = new GameDummySerializer();
        IGameDeserializer gameDeserializer = new GameDummyDeserializer();
        _gameEngine = new GameEngine(_reader, writer, gameSetup, gameSerializer, gameDeserializer);
    }
    
    [Theory]
    [MemberData(nameof(GivesCorrectWinnerTestData))]
    public void Run_GivesCorrectWinner_WhenGivenPlayerInputs(object[] gameInputs, int? winnerPlayerId)
    {
        _reader.FeedInput(gameInputs);
        
        var resultGameState = _gameEngine.Run();
        
        Assert.Equal(winnerPlayerId, resultGameState.Winner?.Id);
    }
    
    [Theory]
    [MemberData(nameof(PlayMultipleRoundsTestData))]
    public void Run_CanPlayMultipleRounds_WhenGivenPlayerInputs(object[] gameInputs, int? winnerPlayerId)
    {
        _reader.FeedInput(gameInputs);
        
        var resultGameState = _gameEngine.Run();
        
        Assert.Equal(winnerPlayerId, resultGameState.Winner?.Id);
    }

    #region Gives correct winner test data
    public static IEnumerable<object[]> GivesCorrectWinnerTestData()
    {
        yield return new object[]
        {
            new object[]
            {
                Constants.No, // Load game
                3, // Game board length
                "Alice", // Player 1 name
                Constants.HumanMoveType , // Player 1 type
                "Bob", // Player 2 name
                Constants.HumanMoveType , // Player 2 type
                1, // Number of rounds
                
                Constants.SetTile,
                1, 1,
                Constants.SetTile,
                1, 2,
                Constants.SetTile,
                2, 2,
                Constants.SetTile,
                1, 3,
                Constants.SetTile,
                3, 3
            },
            0
        };
        yield return new object[]
        {
            new object[]
            {
                Constants.No, // Load game
                3, // Game board length
                "Alice", // Player 1 name
                Constants.HumanMoveType , // Player 1 type
                "Bob", // Player 2 name
                Constants.HumanMoveType , // Player 2 type
                1, // Number of rounds
                
                Constants.SetTile,
                1, 1,
                Constants.SetTile,
                2, 2,
                Constants.SetTile,
                1, 3,
                Constants.SetTile,
                1, 2, 
                Constants.SetTile,
                3, 2,
                Constants.SetTile,
                2, 1,
                Constants.SetTile,
                2, 3,
                Constants.SetTile,
                3, 3,
                Constants.SetTile,
                3, 1
            },
            null!
        };
        yield return new object[]
        {
            new object[]
            {
                Constants.No, // Load game
                3, // Game board length
                "Alice", // Player 1 name
                Constants.HumanMoveType , // Player 1 type
                "Bob", // Player 2 name
                Constants.HumanMoveType , // Player 2 type
                1, // Number of rounds
                
                Constants.SetTile,
                2, 2,
                Constants.SetTile,
                1, 1,
                Constants.SetTile,
                1, 3,
                Constants.SetTile,
                3, 1,
                Constants.SetTile,
                3, 3,
                Constants.SetTile,
                2, 1
            },
            1
        };
    }
    #endregion

    #region Play multiple rounds test data
    public static IEnumerable<object[]> PlayMultipleRoundsTestData()
    {
        yield return new object[]
        {
            new object[]
            {
                Constants.No, // Load game
                3, // Game board length
                "Alice", // Player 1 name
                Constants.HumanMoveType , // Player 1 type
                "Bob", // Player 2 name
                Constants.HumanMoveType , // Player 2 type
                2, // Number of rounds
                
                Constants.SetTile,
                1, 1,
                Constants.SetTile,
                1, 2,
                Constants.SetTile,
                2, 2,
                Constants.SetTile,
                1, 3,
                Constants.SetTile,
                3, 3,
                
                Constants.SetTile,
                1, 1,
                Constants.SetTile,
                1, 2,
                Constants.SetTile,
                2, 2,
                Constants.SetTile,
                1, 3,
                Constants.SetTile,
                3, 3
            },
            0
        };
        yield return new object[]
        {
            new object[]
            {
                Constants.No, // Load game
                3, // Game board length
                "Alice", // Player 1 name
                Constants.HumanMoveType , // Player 1 type
                "Bob", // Player 2 name
                Constants.HumanMoveType , // Player 2 type
                2, // Number of rounds
                
                Constants.SetTile,
                2, 2,
                Constants.SetTile,
                1, 1,
                Constants.SetTile,
                1, 3,
                Constants.SetTile,
                3, 1,
                Constants.SetTile,
                3, 3,
                Constants.SetTile,
                2, 1,
                
                Constants.SetTile,
                2, 2,
                Constants.SetTile,
                1, 1,
                Constants.SetTile,
                1, 3,
                Constants.SetTile,
                3, 1,
                Constants.SetTile,
                3, 3,
                Constants.SetTile,
                2, 1
            },
            1
        };
        yield return new object[]
        {
            new object[]
            {
                Constants.No, // Load game
                3, // Game board length
                "Alice", // Player 1 name
                Constants.HumanMoveType , // Player 1 type
                "Bob", // Player 2 name
                Constants.HumanMoveType , // Player 2 type
                2, // Number of rounds
                
                Constants.SetTile,
                2, 2,
                Constants.SetTile,
                1, 1,
                Constants.SetTile,
                1, 3,
                Constants.SetTile,
                3, 1,
                Constants.SetTile,
                3, 3,
                Constants.SetTile,
                2, 1,
                
                Constants.SetTile,
                1, 1,
                Constants.SetTile,
                1, 2,
                Constants.SetTile,
                2, 2,
                Constants.SetTile,
                1, 3,
                Constants.SetTile,
                3, 3
            },
            null!
        };
    }
    #endregion
}