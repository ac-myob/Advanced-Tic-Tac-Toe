namespace AdvTicTacToe.Game.Business.Model;

public class GameState
{
    public Board Board { get; set; } = null!;
    public char BlankTile { get; set; }
    public List<Player> Players { get; set; } = new();
    public int CurrentPlayerId { get; set; }
    public Player CurrentPlayer => Players[CurrentPlayerId];
    public Player? Winner
    {
        get
        {
            return Players.First().Points != Players.Last().Points ? Players.MaxBy(p => p.Points) : null;
        }
    }
    public int CurrentRound { get; set; } = 1;
    public int TotalRounds { get; set; }
}