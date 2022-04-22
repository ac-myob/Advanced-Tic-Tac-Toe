using AdvTicTacToe.Game.Business.Model;
using Xunit;

namespace AdvTicTacToeTests.GameBoardTests;

public class BoardTests
{
    [Theory]
    [InlineData(3)]
    [InlineData(10)]
    public void BoardConstructor_CreatesNewBoardOfGivenSize_WhenGivenBoardLength(int boardLength)
    {
        // Arrange
        var board = new Board(boardLength);
        
        // Act
        var actualLength = board.Length;
        
        // Assert
        Assert.True(actualLength == boardLength);
    }
}