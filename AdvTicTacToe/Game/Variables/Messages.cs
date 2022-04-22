using AdvTicTacToe.Game.Business.Model;

namespace AdvTicTacToe.Game.Variables;

public static class Messages
{
    public static readonly string InvalidGameRounds = 
        $"Game rounds must be at least {Constants.MinGameRounds}. Please try again: ";
    public const string InvalidExistingName = "Invalid name, name already exists. Please try again: ";
    public const string InvalidInputName = "Invalid name, name cannot be empty. Please try again: ";
    public static readonly string InvalidBoardLength = 
        $"Board length must be at least {Constants.MinBoardLength}. Please try again: ";
    public const string GetNumRounds = "Enter number of game rounds: ";
    public const string GetBoardLength = "Enter board length: ";
    public static readonly Func<int, string> GetPlayerName = playerId => $"Enter name for player {playerId + 1}: ";
    public const string GetPlayerType = 
        $"Choose player type ([{Constants.HumanMoveType}] Human, [{Constants.BadCpuMoveType}] Bad CPU): ";
    public const string GameDraw = "It's a draw!";
    public static readonly Func<Player, string> GetWinner = player => $"{player.Name} wins!";
    public static readonly Func<int, int, string> InvalidGetInt = (min, max) =>
        $"Invalid input, integer must be between {min} and {max} inclusive. Please try again: ";
    public const string InvalidGetChar = "Character must have a length of one. Please try again: ";
    public static readonly Func<string, string> InvalidGetString =
        (regex) => $"String does not match regex ({regex}). Please try again: ";
    public const string GetRow = "Enter row: ";
    public const string GetCol = "Enter col: ";
    public static readonly Func<int, string> InvalidRow = (rowMax) =>
        $"Row must be between {Constants.MinCoord} and {rowMax}. Please try again: ";
    public static readonly Func<int, string> InvalidCol = (colMax) =>
        $"Column must be between {Constants.MinCoord} and {colMax}. Please try again: ";
    public const string InvalidMove = "Invalid move. Please try again.\n";

    public const string LoadGameFile = $"Would you like to load an existing game? [{Constants.Yes}/{Constants.No}]: ";
    public const string LoadGameFilename = "Please type in game filename to load from: ";
    public const string SaveGameFile = $"Would you like to save your game? [{Constants.Yes}/{Constants.No}]: ";
    public const string SaveGameFilename = "Please type in game filename to save to: ";
    public const string GetPlayMoveOption = $"\n[{Constants.SetTile}] Play move\n[{Constants.Quit}] Quit\nChoose option: ";
    public const string AssertSquareBoard = "Board must be square.";
}