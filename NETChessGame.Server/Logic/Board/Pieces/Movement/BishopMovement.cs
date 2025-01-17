using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Board.Pieces.Movement;

public class BishopMovement : BaseMovement
{
    public BishopMovement(Color pieceColor) : base(pieceColor) { }
    public BishopMovement() => throw new NotImplementedException();

    public override bool CanMove(Position from, Position to, Actions currentAction)
    {
        var distanceX = Math.Abs(to.X - from.X);
        var distanceY = Math.Abs(to.Y - from.Y);

        switch (currentAction)
        {
            case Actions.None or Actions.Eat:
                // Bishop can only move diagonally (distanceX == distanceY)
                if (distanceX != distanceY)
                    return false;
                break;

            default:
                return false;
        }

        return true;
    }
}