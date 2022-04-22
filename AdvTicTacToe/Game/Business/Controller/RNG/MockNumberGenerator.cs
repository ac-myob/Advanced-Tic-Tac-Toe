namespace AdvTicTacToe.Game.Business.Controller.RNG;

public class MockNumberGenerator : INumberGenerator
{
    private readonly Queue<int> _randomNumbers;

    public MockNumberGenerator(params int[] randomNumbers)
    {
        _randomNumbers = new Queue<int>(randomNumbers);
    }
    
    public int Next(int min, int max)
    {
        return _randomNumbers.Dequeue();
    }
}