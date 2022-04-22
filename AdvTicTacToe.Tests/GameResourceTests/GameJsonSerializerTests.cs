using System.Collections.Generic;
using System.IO;
using AdvTicTacToe.Game.Business.Controller.GameResource.Serializer;
using AdvTicTacToe.Game.Business.Controller.Move;
using AdvTicTacToe.Game.Business.Controller.RNG;
using AdvTicTacToe.Game.Business.Model;
using AdvTicTacToe.Game.Variables;
using Xunit;

namespace AdvTicTacToeTests.GameResourceTests;

public class GameJsonSerializerTests
{
    [Theory]
    [MemberData(nameof(SerializeTestData))]
    public void ToJsonFile_WritesGameStateToJsonFile_WhenGivenGameState(GameState gameState)
    {
        const string filepath = "../../../../AdvTicTacToe/SavedGames/serialize.json";
        GameJsonSerializer gameJsonSerializer = new();
        
        gameJsonSerializer.ToFile(gameState, filepath);
        var fileExists = File.Exists(filepath);
        // File.Delete(filepath);
        
        Assert.True(fileExists);
    }
    
    public static IEnumerable<object[]> SerializeTestData()
    {
        yield return new object[]
        {
            new GameState
            {
                Players = new List<Player>
                {
                    new()
                    {
                        Name = "Alice", 
                        Points = 0, 
                        Id = 0, 
                        Tile = Constants.P1Tile, 
                        Move = new BadCpuMove(new NumberGenerator())
                    }, 
                    new()
                    {
                        Name = "Bob", 
                        Points = 0, 
                        Id = 1, 
                        Tile = Constants.P2Tile, 
                        Move = new BadCpuMove(new NumberGenerator())
                    }
                },
                Board = new Board(3) {Grid = new[,] {{'X', 'O', 'X'}, {'O', 'O', 'X'}, {'X', 'X', 'X'}} },
                CurrentPlayerId = 1,
                BlankTile = Constants.BlankTile,
                CurrentRound = 1,
                TotalRounds = 3
            }
        };
    }
}