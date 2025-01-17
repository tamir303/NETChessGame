using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Board.Pieces.Movement;

public class KingMovement : BaseMovement
{
    public KingMovement(Color pieceColor) : base(pieceColor) { }
    public KingMovement() => throw new NotImplementedException();

    public override bool CanMove(Position from, Position to, Actions currentAction)
    {
        var distanceX = Math.Abs(to.X - from.X);
        var distanceY = Math.Abs(to.Y - from.Y);

        switch (currentAction)
        {
            case Actions.None or Actions.Eat:
                // King moves one square in any direction
                if (distanceX <= 1 && distanceY <= 1)
                    return true;
                break;

            case Actions.Castle:
                // Handle castling (not implemented yet)
                break;

            default:
                return false;
        }

        return false;
    }
}