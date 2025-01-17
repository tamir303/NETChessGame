using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Board.Pieces.Movement;

public class PawnMovement : BaseMovement
{
    private bool _isFirstMove = true;
    public PawnMovement(Color pieceColor) : base(pieceColor) { }
    public PawnMovement() => throw new NotImplementedException();

    public override bool CanMove(Position from, Position to, Actions currentAction)
    {
        var numOfPossibleSteps = _isFirstMove ? 2 : 1;
        var distanceY = to.Y - from.Y;
        var distanceX = Math.Abs(to.X - from.X);

        // Validate white piece moving down
        if (PieceColor == Color.w && distanceY >= 0) return false;
        // Validate black piece moving up
        if (PieceColor == Color.b && distanceY <= 0) return false;

        switch (currentAction)
        {
            case Actions.None:
                // Validate moving in straight line
                if (distanceX != 0) return false;
                // Validate moving no more than 1/2 steps
                if (Math.Abs(distanceY) > numOfPossibleSteps) return false;
                break;

            case Actions.Eat:
                // Validate moving one tile right or left
                if (distanceX != 1) return false;
                // Validate moving on side up or down
                if (Math.Abs(distanceY) != 1) return false;
                break;

            default:
                return false;
        }

        if (_isFirstMove) _isFirstMove = false;
        return true;
    }
}