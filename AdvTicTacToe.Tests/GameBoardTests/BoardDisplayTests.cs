using System.Collections.Generic;
using AdvTicTacToe.Game.Business.Controller.GameBoard;
using AdvTicTacToe.Game.Business.Model;
using Xunit;

namespace AdvTicTacToeTests.GameBoardTests;

public class BoardDisplayTests
{
    [Theory]
    [MemberData(nameof(GetStringTestData))]
    public void GetString_ReturnsStringRepresentationOfBoard_WhenGivenABoard(Board board, string expectedBoardString)
    {
        var actualBoardString = BoardDisplay.GetString(board);
        
        Assert.Equal(expectedBoardString, actualBoardString);
    }
    
    public static IEnumerable<object[]> GetStringTestData()
    {
        yield return new object[]
        {
            new Board(3) {Grid = new[,] {{'X', 'O', 'X'}, {'.', 'X', '.'}, {'X', '.', 'O'}} },
            
            " X | O | X \n" +
            "---+---+---\n" +
            " . | X | . \n" +
            "---+---+---\n" +
            " X | . | O \n"
        };
    }
}