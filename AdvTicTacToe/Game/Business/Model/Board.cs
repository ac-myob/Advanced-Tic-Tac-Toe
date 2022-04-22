using System.Diagnostics;
using AdvTicTacToe.Game.Variables;

namespace AdvTicTacToe.Game.Business.Model;

public class Board
{
    public char[,] Grid { get; init; }

    public int Length
    {
        get
        {
            Debug.Assert(Grid.GetLength(0) == Grid.GetLength(1), Messages.AssertSquareBoard);
            return Grid.GetLength(0);
        }
    }

    public Board(int boardLength)
    {
        Grid = new char[boardLength, boardLength];
    }
}

