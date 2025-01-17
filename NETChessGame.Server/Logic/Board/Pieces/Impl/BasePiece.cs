using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Movement;

namespace NETChessGame.Server.Logic.Board.Pieces.Impl;

public abstract class BasePiece
{
    public string Id { get; protected set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }

    public BaseMovement Movement { get; private set; }
    public Position Position { get; set; }
    protected Color Color { get; }

    protected BasePiece(Color color, Position initialPosition, BaseMovement movement, string name)
    {
        Color = color;
        Position = initialPosition;
        Movement = movement;
        Name = name;
    }

    protected BasePiece() =>
        throw new NotImplementedException();

    public bool MoveTo(Position newPosition, Actions currentAction)
    {
        if (!Movement.CanMove(Position, newPosition, currentAction)) return false;
        Position = newPosition;
        return true;
    }

    public override string ToString()
    {
        return $"{Name} ({Position.X}, {Position.Y})\n";
    }
}