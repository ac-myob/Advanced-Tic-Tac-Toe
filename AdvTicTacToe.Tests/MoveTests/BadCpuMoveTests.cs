using System.Collections.Generic;
using AdvTicTacToe.Game.Business.Controller.Move;
using AdvTicTacToe.Game.Business.Controller.RNG;
using AdvTicTacToe.Game.Business.Model;
using AdvTicTacToe.Game.Variables;
using Xunit;

namespace AdvTicTacToeTests.MoveTests;

public class BadCpuMoveTests 
{
    [Theory]
    [MemberData(nameof(PlayMoveSetsTileTestData))]
    public void SetPlayerTile_SetsTileAtRandomPosition_WhenFunctionInvoked(GameState gameState, int expectedRow, int expectedCol, int currentPlayerId)
    {
        BadCpuMove badCpuMoveLogic = new(new MockNumberGenerator(0));
        var playerTile = currentPlayerId == 0 ? Constants.P1Tile : Constants.P2Tile;
        gameState.CurrentPlayerId = currentPlayerId;
        
        badCpuMoveLogic.PlayerSetTile(gameState);
        
        Assert.True(gameState.Board.Grid[expectedRow, expectedCol] == playerTile);
    }
    
    public static IEnumerable<object[]> PlayMoveSetsTileTestData()
    {
        yield return new object[]
        {
            new GameState
            {
                BlankTile = Constants.BlankTile,
                Board = new Board(3) {Grid = new[,] {{'.', '.', '.'}, {'.', '.', '.'}, {'.', '.', '.'}} },
                Players = new List<Player> {new() {Tile = Constants.P1Tile}, new() {Tile = Constants.P2Tile}}
            },
            0, 0,
            0
        };
        
        yield return new object[]
        {
            new GameState
            {
                BlankTile = Constants.BlankTile,
                Board = new Board(3) {Grid = new[,] {{'X', '.', 'O'}, {'.', '.', '.'}, {'.', '.', '.'}} },
                Players = new List<Player> {new() {Tile = Constants.P1Tile}, new() {Tile = Constants.P2Tile}}
            },
            0, 1,
            1
        };
    }
}