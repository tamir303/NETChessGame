using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Logic.Board
{
    public interface IBoard
    {
        IEnumerable<BasePiece> GetCurrentState();

        BasePiece? GetPieceById(string id);
        BasePiece? GetPieceByPosition(Position position);

        void AddPiece(BasePiece piece);
        void RemovePiece(BasePiece piece);
    }
}
