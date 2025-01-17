using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Manager
{
    public interface IModel
    {
        IEnumerable<BasePiece> GetCurrentState();
    }
}
