using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Board.Pieces.Movement;

public class QueenMovement : BaseMovement
{
    public QueenMovement(Color pieceColor) : base(pieceColor) { }
    public QueenMovement() => throw new NotImplementedException();

    public override bool CanMove(Position from, Position to, Actions currentAction)
    {
        // Queen can move like a rook (straight lines) or bishop (diagonal lines)
        var distanceX = Math.Abs(to.X - from.X);
        var distanceY = Math.Abs(to.Y - from.Y);

        switch (currentAction)
        {
            case Actions.None or Actions.Eat:
                // Queen can move in straight lines (same row or same column) or diagonally
                if (distanceX == distanceY)
                    return true;

                if (distanceX != 0 && distanceY != 0)
                    return false;
                break;

            default:
                return false;
        }

        return true;
    }
}