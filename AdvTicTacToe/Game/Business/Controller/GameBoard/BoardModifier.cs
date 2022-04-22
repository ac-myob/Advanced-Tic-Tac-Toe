using AdvTicTacToe.Game.Business.Model;

namespace AdvTicTacToe.Game.Business.Controller.GameBoard;
public static class BoardModifier
{
    public static void Populate(Board board, char tile)
    {
        for (var rowIndex = 0; rowIndex < board.Length; rowIndex++)
            for (var colIndex = 0; colIndex < board.Length; colIndex++)
                board.Grid[rowIndex, colIndex] = tile;
    }

    public static void SetTile(Board board, int row, int col, char tile)
    {
        board.Grid[row, col] = tile;
    }
}