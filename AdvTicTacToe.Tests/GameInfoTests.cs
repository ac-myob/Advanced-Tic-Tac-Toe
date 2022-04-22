using System.Collections.Generic;
using AdvTicTacToe.Game.Business.Controller;
using AdvTicTacToe.Game.Business.Model;
using AdvTicTacToe.Game.Variables;
using Xunit;

namespace AdvTicTacToeTests;

public class GameInfoTests
{
    
    [Theory]
    [MemberData(nameof(CurrentRoundTestData))]
    public void GetInfo_ReturnsStringWithCurrentRoundNumber_WhenGivenGameState(GameState gameState, string expectedInfo)
    {
        var actualInfo = GameInfo.GetInfo(gameState);
        
        Assert.Contains(expectedInfo, actualInfo);
    }
    
    [Theory]
    [MemberData(nameof(PlayerPointsTestData))]
    public void GetInfo_ReturnsStringWithPlayerPoints_WhenGivenGameState(GameState gameState, string expectedInfo)
    {
        var actualInfo = GameInfo.GetInfo(gameState);
        
        Assert.Contains(expectedInfo, actualInfo);
    }
    
    [Theory]
    [MemberData(nameof(CurrentPlayerTestData))]
    public void GetInfo_ReturnsStringWithCurrentPlayerTurn_WhenGivenGameState(GameState gameState, string expectedInfo)
    {
        var actualInfo = GameInfo.GetInfo(gameState);
        
        Assert.Contains(expectedInfo, actualInfo);
    }

    public static IEnumerable<object[]> CurrentRoundTestData()
    {
        yield return new object[]
        {
            new GameState
            {
                CurrentRound = 1, 
                TotalRounds = 3,
                Players = new List<Player> { new() {Name = "Alice"}, new() {Name = "Bob"} }
            },
            "Round: 1/3\n"
        };
        yield return new object[]
        {
            new GameState
            {
                CurrentRound = 1, 
                TotalRounds = 1,
                Players = new List<Player> { new() {Name = "Alice"}, new() {Name = "Bob"} }
                
            },
            "Round: 1/1\n"
        };
        yield return new object[]
        {
            new GameState { 
                CurrentRound = 4, 
                TotalRounds = 7,
                Players = new List<Player> { new() {Name = "Alice"}, new() {Name = "Bob"} }
            },
            "Round: 4/7\n"
        };
    }
    
    public static IEnumerable<object[]> PlayerPointsTestData()
    {
        yield return new object[]
        {
            new GameState
            {
                Players = new List<Player> { new() {Name = "Alice", Points = 3}, new() {Name = "Bob", Points = 7} }
            },
            "Alice: 3\nBob: 7\n"
        };
    }
    
    public static IEnumerable<object[]> CurrentPlayerTestData()
    {
        yield return new object[]
        {
            new GameState
            {
                Players = new List<Player>
                {
                    new()
                    {
                        Tile = Constants.P1Tile,
                        Name = "Alice"
                    }, 
                    new()
                    {
                        Tile = Constants.P2Tile,
                        Name = "Bob"
                    }
                },
                CurrentPlayerId = 0
            },
            "Current player: Alice\n"
        };
        
        yield return new object[]
        {
            new GameState
            {
                Players = new List<Player>
                {
                    new()
                    {
                        Tile = Constants.P1Tile,
                        Name = "Alice"
                    }, 
                    new()
                    {
                        Tile = Constants.P2Tile,
                        Name = "Bob"
                    }
                },
                CurrentPlayerId = 1
            },
            "Current player: Bob\n"
        };
    }
}