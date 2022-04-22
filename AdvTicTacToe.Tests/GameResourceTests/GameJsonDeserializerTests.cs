using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdvTicTacToe.Game.Business.Controller.GameResource.Deserializer;
using AdvTicTacToe.Game.Business.Controller.GameResource.Serializer;
using AdvTicTacToe.Game.Business.Controller.Move;
using AdvTicTacToe.Game.Business.Controller.RNG;
using AdvTicTacToe.Game.Business.Model;
using AdvTicTacToe.Game.Variables;
using Xunit;

namespace AdvTicTacToeTests.GameResourceTests;

public class GameJsonDeserializerTests
{
    [Theory]
    [MemberData(nameof(DeserializeTestData))]
    public void FromFile_ReturnsGameStateFromJsonFile_WhenGivenJsonFile(GameState gameState)
    {
        const string filepath = "../../../../AdvTicTacToe/SavedGames/deserialize.json";
        GameJsonSerializer gameJsonSerializer = new();
        GameJsonDeserializer gameJsonDeserializer = new();

        gameJsonSerializer.ToFile(gameState, filepath);
        var loadedGameState = gameJsonDeserializer.FromFile(filepath);
        var sameBoard = gameState.Board.Grid.Cast<char>().SequenceEqual(loadedGameState.Board.Grid.Cast<char>());
        File.Delete(filepath);

        Assert.True(sameBoard);
    }
    
    public static IEnumerable<object[]> DeserializeTestData()
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