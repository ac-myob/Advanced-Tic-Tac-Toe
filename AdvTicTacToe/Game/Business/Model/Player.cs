using AdvTicTacToe.Game.Business.Controller.Move;
using Newtonsoft.Json;

namespace AdvTicTacToe.Game.Business.Model;

public class Player
{
    public string Name { get; set; }
    public int Id { get; set; }
    public char Tile { get; set; }
    public int Points { get; set; }
    [JsonProperty]
    public IMove Move { get; set; } = null!;
}