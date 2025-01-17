using Type = NETChessGame.Server.Logic.Board.Pieces.Enums.Type;
using NETChessGame.Server.Logic.Board.Pieces.Impl;
using NETChessGame.Server.Logic.Board.Pieces.Enums;

namespace NETChessGame.Server.Logic.Board
{
    public abstract class Factory
    {
        public static BasePiece CreatePiece(Type type, Color color, Position position)
        {
            return type switch
            {
                Type.bishop => new Bishop(color, position),
                Type.king => new King(color, position),
                Type.knight => new Knight(color, position),
                Type.pawn => new Pawn(color, position),
                Type.queen => new Queen(color, position),
                Type.rook => new Rook(color, position),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
