using AdvTicTacToe.Game.Business.Model;

namespace AdvTicTacToe.Game.Business.Controller.GameBoard;

public static class BoardDisplay
{
    public static string GetString(Board board)
    {

        var res = "";

        for (var rowIndex = 0; rowIndex < board.Length; rowIndex++)
        {
            var currentRow = "";
            for (var colIndex = 0; colIndex < board.Length; colIndex++)
                currentRow +=  $"{(currentRow == "" ? "" : "|")} {board.Grid[rowIndex, colIndex]} ";

            res += currentRow + "\n" + (rowIndex != board.Length - 1 ? _getHorizontalSeparator(board) + "\n" : "");
        }

        return res;
    }

    private static string _getHorizontalSeparator(Board board)
    {
        var singleHorzSep = "---";
        var res = singleHorzSep;
        
        for (var rows = 0; rows < board.Length - 1; rows++)
            res += $"+{singleHorzSep}";

        return res;
    }
}