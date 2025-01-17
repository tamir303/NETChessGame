using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Board.Pieces.Movement;

public class KnightMovement : BaseMovement
{
    public KnightMovement(Color pieceColor) : base(pieceColor) { }
    public KnightMovement() => throw new NotImplementedException();

    public override bool CanMove(Position from, Position to, Actions currentAction)
    {
        var distanceY = to.Y - from.Y;
        var distanceX = Math.Abs(to.X - from.X);

        switch (currentAction)
        {
            case Actions.None or Actions.Eat:
                // Knight moves in an "L" shape: 2 squares in one direction, 1 square in the other
                if (distanceX == 2 && distanceY == 1 || distanceX == 1 && distanceY == 2)
                    return true;
                break;

            default:
                return false;
        }

        return false;
    }
}