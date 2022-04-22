using System.Linq;
using AdvTicTacToe.Game.Business.Controller.GameBoard;
using AdvTicTacToe.Game.Business.Model;
using Xunit;

namespace AdvTicTacToeTests.GameBoardTests;

public class BoardModifierTests
{
    [Theory]
    [InlineData(3, '.')]
    [InlineData(8, '_')]
    public void Populate_SetsAllTilesToAGivenTile_WhenGivenATile(int boardLength, char populateTile)
    {
        var board = new Board(boardLength);
        
        BoardModifier.Populate(board, populateTile);

        var result = board.Grid.Cast<char>().Aggregate(true, (acc, tile) => acc && tile == populateTile);

        Assert.True(result);
    }

    [Theory]
    [InlineData(3, 0, 0, 'X')]
    public void SetTile_MutatesSpecificTile_WhenGivenATile(int boardLength, int row, int col, char tile)
    {
        var board = new Board(boardLength);

        BoardModifier.SetTile(board, row, col, tile);
        
        Assert.True(board.Grid[row, col] == tile);
    }
}