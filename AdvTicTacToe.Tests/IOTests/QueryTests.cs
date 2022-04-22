using AdvTicTacToe.Game.Business.View.IO;
using Xunit;

namespace AdvTicTacToeTests.IOTests;

public class QueryTests
{
    [Theory]
    [InlineData(1, 7, new object[] {"10", "1.33", "21", "abc", "3"}, 3)]
    public void QueryInt_ReturnsIntegerBetweenRange_WhenGivenNumberRange(int min, int max, object[] trials, int expected)
    {
        var reader = new MockReader(trials);
        var writer = new DummyWriter();
        var query = new Query(reader, writer);

        var actual = query.GetInt(min, max);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(".+", new[] {"", "hi"}, "hi")]
    public void QueryString_ReturnsStringMatchingRegex_WhenGivenRegex(string regex, object[] input, string expected)
    {
        var reader = new MockReader(input);
        var writer = new DummyWriter();
        var query = new Query(reader, writer);

        var actual = query.GetString(regex);
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(".+", new[] {"asdf", "hi", "X"}, 'X')]
    public void QueryChar_ReturnsACharacter_WhenUserInputIsRead(string regex, object[] input, char expected)
    {
        var reader = new MockReader(input);
        var writer = new DummyWriter();
        var query = new Query(reader, writer);

        var actual = query.GetChar();
        
        Assert.Equal(expected, actual);
    }
}

