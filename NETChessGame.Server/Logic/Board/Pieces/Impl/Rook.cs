using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Movement;
using Type = NETChessGame.Server.Logic.Board.Pieces.Enums.Type;

namespace NETChessGame.Server.Logic.Board.Pieces.Impl;

public class Rook : BasePiece
{
    public Rook(Color color, Position initialPosition)
        : base(color, initialPosition, new RookMovement(color), $"{Type.rook}-{color}")
    {

    }
    public Rook() => throw new NotImplementedException();
}