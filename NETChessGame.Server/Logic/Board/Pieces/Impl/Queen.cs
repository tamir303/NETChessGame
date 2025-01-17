using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Movement;
using Type = NETChessGame.Server.Logic.Board.Pieces.Enums.Type;

namespace NETChessGame.Server.Logic.Board.Pieces.Impl;

public class Queen : BasePiece
{
    public Queen(Color color, Position initialPosition)
        : base(color, initialPosition, new QueenMovement(color), $"{Type.queen}-{color}")
    {

    }
    public Queen() => throw new NotImplementedException();
}