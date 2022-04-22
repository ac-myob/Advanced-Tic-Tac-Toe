using AdvTicTacToe.Game.Business.Model;

namespace AdvTicTacToe.Game.Business.Controller.GameBoard;

public static class BoardValidator
{
    public static bool IsValidMove(Board board, int row, int col, char tile)
    {
        var validRow = 0 <= row && row < board.Length;
        var validCol = 0 <= col && col < board.Length;
        return validRow && validCol && board.Grid[row, col] == tile;
    }

    public static bool HasMatch(Board board, char tile)
    {
        return _hasRowMatch(board, tile) || 
               _hasColMatch(board, tile) ||
               _hasTopLeftDiagMatch(board, tile) ||
               _hasTopRightDiagMatch(board, tile);
    }
    
    private static bool _hasRowMatch(Board board, char tile)
    {
        for (var rowIndex = 0; rowIndex < board.Length; rowIndex++)
        {
            var numberOfTiles = 0;
            for (var colIndex = 0; colIndex < board.Length; colIndex++) 
                if (board.Grid[rowIndex, colIndex] == tile) 
                    ++numberOfTiles;
            if (numberOfTiles == board.Length) 
                return true;
        }
 
        return false;
    }

    private static bool _hasColMatch(Board board, char tile)
    {
        for (var colIndex = 0; colIndex < board.Length; colIndex++)
        {
            var numberOfTiles = 0;
            for (var rowIndex = 0; rowIndex < board.Length; rowIndex++) 
                if (board.Grid[rowIndex, colIndex] == tile) 
                    ++numberOfTiles;
            if (numberOfTiles == board.Length) 
                return true;
        }
 
        return false;
    }
    
    private static bool _hasTopLeftDiagMatch(Board board, char tile)
    {
        var numberOfTiles = 0;
        for (var index = 0; index < board.Length; index++)
            if (board.Grid[index, index] == tile)
                ++numberOfTiles;
        
        return numberOfTiles == board.Length;
    }
    
    private static bool _hasTopRightDiagMatch(Board board, char tile)
    {
        var numberOfTiles = 0;
        for (var index = 0; index < board.Length; index++)
            if (board.Grid[board.Length - 1 - index, index] == tile)
                ++numberOfTiles;
        
        return numberOfTiles == board.Length;
    }

    public static bool HasTile(Board board, char matchTile)
    {
        return board.Grid.Cast<char>().Any(tile => tile == matchTile);
    }
}