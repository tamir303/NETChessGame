using NETChessGame.Server.Logic.Board;
using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Manager
{
    public class GameManager : IModel
    {
        private readonly IBoard Board = new GameBoard();

        public IEnumerable<BasePiece> GetCurrentState()
        {
            return Board.GetCurrentState();
        }
    }
}
