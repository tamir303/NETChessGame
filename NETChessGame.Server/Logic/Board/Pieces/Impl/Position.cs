namespace NETChessGame.Server.Logic.Board.Pieces.Impl
{
    public record Position(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
    }
}