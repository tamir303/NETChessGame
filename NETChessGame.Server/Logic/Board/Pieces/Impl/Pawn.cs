using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Movement;
using Type = NETChessGame.Server.Logic.Board.Pieces.Enums.Type;

namespace NETChessGame.Server.Logic.Board.Pieces.Impl;

public class Pawn : BasePiece
{

    public Pawn(Color color, Position initialPosition)
        : base(color, initialPosition, new PawnMovement(color), $"{Type.pawn}-{color}")
    {

    }
    public Pawn() => throw new NotImplementedException();
}