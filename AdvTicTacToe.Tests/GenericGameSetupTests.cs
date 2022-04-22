using System;
using System.Linq;
using AdvTicTacToe.Game.Business.Controller.GameSetup;
using AdvTicTacToe.Game.Business.Controller.Move;
using AdvTicTacToe.Game.Business.View.IO;
using AdvTicTacToe.Game.Variables;
using Xunit;

namespace AdvTicTacToeTests;

public class GenericGameSetupTests
{
    [Theory]
    [InlineData(3)]
    [InlineData(10)]
    public void GetNewState_CreatesEmptyBoardOfGivenSize_WhenQueriedForBoardLength(int boardLength)
    {
        var reader = new MockReader(boardLength, "Alice", "H", "Bob", "H", 1);
        var writer = new DummyWriter();
        var gameSetup = new GameSetupGeneric(reader, writer);
        var newGameState = gameSetup.GetNewGameState();

        var blankTileCount = newGameState.Board.Grid.Cast<char>().Sum(tile => tile == Constants.BlankTile ? 1 : 0);
        
        Assert.True(blankTileCount == boardLength * boardLength);
    }

    [Theory]
    [InlineData("Alice", "H", typeof(HumanMove), "Bob", "H", typeof(HumanMove))]
    [InlineData("Alice", "H", typeof(HumanMove), "Bob", "B", typeof(BadCpuMove))]
    public void GetNewState_SetsPlayerInfo_WhenQueriedPlayerNameAndMove(
        string p1Name, string p1Move, Type p1ExpectedMoveType, 
        string p2Name, string p2Move, Type p2ExpectedMoveType)
    {
        var reader = new MockReader(3, p1Name, p1Move, p2Name, p2Move, 1);
        var writer = new DummyWriter();
        var gameSetup = new GameSetupGeneric(reader, writer);
        var newGameState = gameSetup.GetNewGameState();

        var correctNames = newGameState.Players.Select(p => p.Name).SequenceEqual(new[] {p1Name, p2Name});
        var correctMoveLogic = newGameState.Players.Select(p => p.Move.GetType()).SequenceEqual(new[] {p1ExpectedMoveType, p2ExpectedMoveType});

        Assert.True(correctNames && correctMoveLogic);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public void GetNewState_SetsTotalRounds_WhenQueriedForTotalRounds(int totalRounds)
    {
        var reader = new MockReader(3, "Alice", "H", "Bob", "H", totalRounds);
        var writer = new DummyWriter();
        var gameSetup = new GameSetupGeneric(reader, writer);
        var newGameState = gameSetup.GetNewGameState();

        Assert.Equal(totalRounds, newGameState.TotalRounds);
    }

    public void LoadState_ReturnsGameStateFromJsonFile_WhenGivenJsonFile()
    {
        
    }
}