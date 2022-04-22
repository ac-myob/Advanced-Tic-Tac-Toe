using System.Text.RegularExpressions;
using AdvTicTacToe.Game.Variables;
using Newtonsoft.Json;

namespace AdvTicTacToe.Game.Business.View.IO;

public class Query
{
    [JsonProperty]
    private readonly IReader _reader;
    [JsonProperty]
    private readonly IWriter _writer;
    public Query(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public int GetInt(int min = int.MinValue, int max = int.MaxValue, string? invalidInputMsg = null)
    {
        invalidInputMsg ??= Messages.InvalidGetInt(min, max);
        var readValue = _reader.Read();
        int res;
        while (!int.TryParse(readValue, out res) || !(min <= res && res < max))
        {
            _writer.Write(invalidInputMsg);
            readValue = _reader.Read();
        }

        return res;
    }

    public string GetString(string regex, string? invalidInputMsg = null)
    {
        invalidInputMsg ??= Messages.InvalidGetString(regex);
        var readValue = _reader.Read();
        while (!Regex.IsMatch(readValue, regex))
        {
            _writer.Write(invalidInputMsg); 
            readValue = _reader.Read();
        }

        return readValue;
    }
    
    public char GetChar(string? invalidInputMsg = null)
    {
        invalidInputMsg ??= Messages.InvalidGetChar;
        var readValue = _reader.Read();
        char res;
        while (!char.TryParse(readValue, out res))
        {
            _writer.Write(invalidInputMsg); 
            readValue = _reader.Read();
        }

        return res;
    }
}