using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Board.Pieces.Movement;

public class RookMovement : BaseMovement
{
    public RookMovement(Color pieceColor) : base(pieceColor) { }
    public RookMovement() => throw new NotImplementedException();

    public override bool CanMove(Position from, Position to, Actions currentAction)
    {
        var distanceX = Math.Abs(to.X - from.X);
        var distanceY = Math.Abs(to.Y - from.Y);

        switch (currentAction)
        {
            case Actions.None or Actions.Eat:
                // Rook can only move horizontally or vertically
                if (distanceX == 0 || distanceY == 0)
                    return true;
                break;

            default:
                return false;
        }

        return false;
    }
}