using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Movement;
using Type = NETChessGame.Server.Logic.Board.Pieces.Enums.Type;

namespace NETChessGame.Server.Logic.Board.Pieces.Impl;

public class King : BasePiece
{

    public King(Color color, Position initialPosition)
        : base(color, initialPosition, new KingMovement(color), $"{Type.king}-{color}")
    {

    }
    public King() => throw new NotImplementedException();
}