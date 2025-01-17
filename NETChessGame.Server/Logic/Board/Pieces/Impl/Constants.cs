namespace NETChessGame.Server.Logic.Board.Pieces.Impl;

public sealed class Constants
{
    public static Position BlackBishopInitialPosition = new(2, 0);
    public static Position BlackKingInitialPosition = new(4, 0);
    public static Position BlackKnightInitialPosition = new(1, 0);
    public static Position BlackPawnInitialPosition = new(0, 1);
    public static Position BlackQueenInitialPosition = new(3, 0);
    public static Position BlackRookInitialPosition = new(0, 0);

    public static Position WhiteBishopInitialPosition = new(5, 7);
    public static Position WhiteKingInitialPosition = new(3, 7);
    public static Position WhiteKnightInitialPosition = new(6, 7);
    public static Position WhitePawnInitialPosition = new(7, 6);
    public static Position WhiteQueenInitialPosition = new(4, 7);
    public static Position WhiteRookInitialPosition = new(7, 7);
}
