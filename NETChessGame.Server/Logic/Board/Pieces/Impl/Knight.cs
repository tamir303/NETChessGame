using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Movement;
using Type = NETChessGame.Server.Logic.Board.Pieces.Enums.Type;

namespace NETChessGame.Server.Logic.Board.Pieces.Impl;

public class Knight : BasePiece
{

    public Knight(Color color, Position initialPosition)
        : base(color, initialPosition, new KnightMovement(color), $"{Type.knight}-{color}")
    {

    }
    public Knight() => throw new NotImplementedException();
}