namespace AdvTicTacToe.Game.Variables;

public static class Constants
{
    public const char P1Tile = 'O';
    public const char P2Tile = 'X';
    public const char BlankTile = '.';
    public const int MinBoardLength = 3;
    public const int MinGameRounds = 1;
    public const int MinCoord = 1;
    public const string AnyOneOrMoreCharRegex = ".+";
    public const string HumanMoveType = "H";
    public const string BadCpuMoveType = "B";
    public const string PlayerMoveTypeOptionsRegex = $"{HumanMoveType}|{BadCpuMoveType}";
    public const string Yes = "y";
    public const string No = "n";
    public const string YesOrNoRegex = $"^{Yes}|{No}$";
    public const string SetTile = "s";
    public const string Quit = "q";
    public const string PlayMoveOptionsRegex = $"^{SetTile}|{Quit}$";
}