using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Movement;
using Type = NETChessGame.Server.Logic.Board.Pieces.Enums.Type;

namespace NETChessGame.Server.Logic.Board.Pieces.Impl;

public class Bishop : BasePiece
{

    public Bishop(Color color, Position initialPosition)
        : base(color, initialPosition, new BishopMovement(color), $"{Type.bishop}-{color}")
    {

    }
    public Bishop() => throw new NotImplementedException();
}