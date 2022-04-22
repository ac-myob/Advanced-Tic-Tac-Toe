using System.Collections.Generic;
using AdvTicTacToe.Game.Business.Controller.Move;
using AdvTicTacToe.Game.Business.Model;
using AdvTicTacToe.Game.Business.View.IO;
using AdvTicTacToe.Game.Exceptions;
using AdvTicTacToe.Game.Variables;
using Xunit;

namespace AdvTicTacToeTests.MoveTests;

public class HumanMoveTests
{
    private readonly HumanMove _humanMove;
    private readonly MockReader _mockReader = new();
    
    public HumanMoveTests()
    {
        _humanMove = new HumanMove(_mockReader, new DummyWriter());
    }
    
    
    [Theory]
    [MemberData(nameof(PlayerSetsTileTestData))]
    public void SetPlayerTile_SetsTileAtRandomPosition_WhenPlayerChoosesToPlayMove(GameState gameState, char playerMoveOption, int inputRow, int inputCol, int currentPlayerId, char expectedTile)
    {
        _mockReader.FeedInput(playerMoveOption, inputRow, inputCol);
        gameState.CurrentPlayerId = currentPlayerId;

        _humanMove.PlayerSetTile(gameState);
    
        Assert.True(gameState.Board.Grid[inputRow - 1, inputCol - 1] == expectedTile);
    }
    
    [Theory]
    [MemberData(nameof(PlayerQuitTestData))]
    public void SetPlayerTile_ThrowsPlayerQuitException_WhenPlayerChoosesToQuit(GameState gameState, char playerMoveOption)
    {
        _mockReader.FeedInput(playerMoveOption);

        Assert.Throws<PlayerQuitException>(() => _humanMove.PlayerSetTile(gameState));
    }
    
    # region Player sets tile test data
    public static IEnumerable<object[]> PlayerSetsTileTestData()
    {
        yield return new object[]
        {
            new GameState
            {
                BlankTile = Constants.BlankTile,
                Board = new Board(3) {Grid = new[,] {{'.', '.', '.'}, {'.', '.', '.'}, {'.', '.', '.'}} },
                Players = new List<Player> {new() {Tile = Constants.P1Tile}, new() {Tile = Constants.P2Tile}}
            },
            Constants.SetTile,
            1, 1,
            0,
            Constants.P1Tile
        };
        
        yield return new object[]
        {
            new GameState
            {
                BlankTile = Constants.BlankTile,
                Board = new Board(3) {Grid = new[,] {{'X', '.', 'O'}, {'.', '.', '.'}, {'.', '.', '.'}} },
                Players = new List<Player> {new() {Tile = Constants.P1Tile}, new() {Tile = Constants.P2Tile}}
            },
            Constants.SetTile,
            1, 2,
            1,
            Constants.P2Tile
        };
    }
    # endregion
    
    #region Player quit test data
    public static IEnumerable<object[]> PlayerQuitTestData()
    {
        yield return new object[]
        {
            new GameState
            {
                BlankTile = Constants.BlankTile,
                Board = new Board(3) {Grid = new[,] {{'.', '.', '.'}, {'.', '.', '.'}, {'.', '.', '.'}} },
                Players = new List<Player> {new() {Tile = Constants.P1Tile}, new() {Tile = Constants.P2Tile}}
            },
            Constants.Quit
        };
    }
    #endregion
}