using System.Collections.Generic;
using AdvTicTacToe.Game.Business.Controller.GameBoard;
using AdvTicTacToe.Game.Business.Model;
using Xunit;

namespace AdvTicTacToeTests.GameBoardTests;

public class BoardValidatorTests
{
    
    [Theory]
    [MemberData(nameof(IsValidMoveTestData))]
    public void IsValidMove_ReturnsTrueIfTileCanBeSetOnCoordinateElseFalse_WhenGivenCoordinateAndTile(Board board, int row, int col, char blankTile, bool expected)
    {
       var actual = BoardValidator.IsValidMove(board, row, col, blankTile);
       
       Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(RowMatchTestData))]
    public void HasMatch_ReturnsTrueIfRowMatchIsFoundElseFalse_WhenGivenBoardAndTile(Board board, char tile, bool expected)
    {
        var actual = BoardValidator.HasMatch(board, tile);
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(ColumnMatchTestData))]
    public void HasMatch_ReturnsTrueIfColumnMatchIsFoundElseFalse_WhenGivenBoardAndTile(Board board, char tile, bool expected)
    {
        var actual = BoardValidator.HasMatch(board, tile);
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(TopLeftDiagonalMatchTestData))]
    public void HasMatch_ReturnsTrueIfTopLeftDiagonalMatchIsFoundElseFalse_WhenGivenBoardAndTile(Board board, char tile, bool expected)
    {
        var actual = BoardValidator.HasMatch(board, tile);
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(TopRightDiagonalMatchTestData))]
    public void HasMatch_ReturnsTrueIfTopRightDiagonalMatchIsFoundElseFalse_WhenGivenBoardAndTile(Board board, char tile, bool expected)
    {
        var actual = BoardValidator.HasMatch(board, tile);
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(HasTileDataTest))]
    public void HasTile_ReturnsTrueIfBoardContainsTile_WhenGivenATile(Board board, char matchTile, bool expected)
    {
        var actual = BoardValidator.HasTile(board, matchTile);
        
        Assert.Equal(expected, actual);
    }
    
    public static IEnumerable<object[]> IsValidMoveTestData()
    {
        yield return new object[] {new Board(3) {Grid = new[,] {{'X', 'X', 'X'}, {'.', '.', '.'}, {'.', '.', '.'}} }, 0, 0, '.', false};
        yield return new object[] {new Board(3) {Grid = new[,] {{'X', 'X', 'X'}, {'.', '.', '.'}, {'.', '.', '.'}} }, 1, 1, '.', true};
    }
    
    public static IEnumerable<object[]> RowMatchTestData()
    {
        yield return new object[] {new Board(3) {Grid = new[,] {{'X', 'X', 'X'}, {'.', '.', '.'}, {'.', '.', '.'}} }, 'X', true};
        yield return new object[] {new Board(3) {Grid = new[,] {{'.', '.', '.'}, {'X', 'X', 'X'}, {'.', '.', '.'}} }, 'X', true};
        yield return new object[] {new Board(3) {Grid = new[,] {{'.', '.', '.'}, {'.', '.', '.'}, {'X', 'X', 'X'}} }, 'X', true};
        yield return new object[] {new Board(3) {Grid = new[,] {{'.', '.', '.'}, {'.', 'X', '.'}, {'X', '.', 'X'}} }, 'X', false};
    }
    
    public static IEnumerable<object[]> ColumnMatchTestData()
    {
        yield return new object[] {new Board(3) {Grid = new[,] {{'X', '.', '.'}, {'X', '.', '.'}, {'X', '.', '.'}} }, 'X', true};
        yield return new object[] {new Board(3) {Grid = new[,] {{'.', 'X', '.'}, {'.', 'X', '.'}, {'.', 'X', '.'}} }, 'X', true};
        yield return new object[] {new Board(3) {Grid = new[,] {{'.', '.', 'X'}, {'.', '.', 'X'}, {'.', '.', 'X'}} }, 'X', true};
        yield return new object[] {new Board(3) {Grid = new[,] {{'.', '.', '.'}, {'.', 'X', '.'}, {'X', '.', 'X'}} }, 'X', false};
    }
    
    public static IEnumerable<object[]> TopLeftDiagonalMatchTestData()
    {
        yield return new object[] {new Board(3) {Grid = new[,] {{'X', '.', '.'}, {'.', 'X', '.'}, {'.', '.', 'X'}} }, 'X', true};
        yield return new object[] {new Board(3) {Grid = new[,] {{'.', '.', '.'}, {'.', 'X', '.'}, {'X', '.', 'X'}} }, 'X', false};
    }
    
    public static IEnumerable<object[]> TopRightDiagonalMatchTestData()
    {
        yield return new object[] {new Board(3) {Grid = new[,] {{'.', '.', 'X'}, {'.', 'X', '.'}, {'X', '.', '.'}} }, 'X', true};
        yield return new object[] {new Board(3) {Grid = new[,] {{'.', '.', '.'}, {'.', 'X', '.'}, {'X', '.', 'X'}} }, 'X', false};
    }
    
    public static IEnumerable<object[]> HasTileDataTest()
    {
        yield return new object[] {new Board(3) {Grid = new[,] {{'X', 'O', 'X'}, {'O', 'O', 'X'}, {'X', 'X', 'X'}} }, '.', false};
        yield return new object[] {new Board(3) {Grid = new[,] {{'.', '.', '.'}, {'.', 'X', '.'}, {'X', '.', 'X'}} }, '.', true};
    }
}