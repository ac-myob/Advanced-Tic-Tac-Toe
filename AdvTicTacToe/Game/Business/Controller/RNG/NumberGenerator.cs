namespace AdvTicTacToe.Game.Business.Controller.RNG;

public class NumberGenerator : INumberGenerator
{
    private readonly Random _rng = new();
    
    public int Next(int min, int max)
    {
        return _rng.Next(min, max + 1);
    }
}