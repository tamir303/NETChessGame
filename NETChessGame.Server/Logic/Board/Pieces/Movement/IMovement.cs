using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Board.Pieces.Movement;

public interface IMovement
{
    bool CanMove(Position from, Position to, Actions currentAction);
}