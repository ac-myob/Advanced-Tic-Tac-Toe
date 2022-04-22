namespace AdvTicTacToe.Game.Business.Controller.RNG;

public interface INumberGenerator
{
    public int Next(int min, int max);
}