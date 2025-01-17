using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Board.Pieces.Movement;

public abstract class BaseMovement : IMovement
{
    protected Color PieceColor;

    protected BaseMovement(Color pieceColor)
    {
        PieceColor = pieceColor;
    }

    protected BaseMovement() => throw new NotImplementedException();

    public abstract bool CanMove(Position from, Position to, Actions currentAction);

    public List<(Position cord, string action)> GetAllPossibleMoves(Position from, List<(Position cord, string status, string color)> boardRange)
    {
        return boardRange
            .Select(pos =>
            {
                var (cord, status, color) = pos;

                if (status == "Occupied" && color.Equals(PieceColor.ToString()) && CanMove(from, cord, Actions.Eat))
                    return (cord, action: Actions.Eat);

                if (status != "Occupied" && CanMove(from, cord, Actions.None))
                    return (cord, action: Actions.None);

                return (cord: default(Position), action: Actions.Invalid);
            })
            .Where(move => move.action != Actions.Invalid)
            .Cast<(Position cord, string action)>()
            .ToList();
    }
}