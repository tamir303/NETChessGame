using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Impl;
using System.Collections.Generic;
using PiecesFactory = NETChessGame.Server.Logic.Board.Factory;
using Type = NETChessGame.Server.Logic.Board.Pieces.Enums.Type;

namespace NETChessGame.Server.Logic.Board
{
    public class GameBoard : IBoard
    {
        public const int SIZE = 8;

        public Dictionary<Position, BasePiece> BoardPositionsDict;
        public Dictionary<string, BasePiece> BoardIdsDict;

        public GameBoard() 
        {
            this.BoardIdsDict = [];
            this.BoardPositionsDict = [];

            this.InitalizeBoard();
        }

        public IEnumerable<BasePiece> GetCurrentState()
        {
            return BoardIdsDict.Values;
        }

        public BasePiece? GetPieceById(string id)
        {
            return BoardIdsDict.TryGetValue(id, out var piece) ? piece : null;
        }

        public BasePiece? GetPieceByPosition(Position position)
        {
            return BoardPositionsDict.TryGetValue(position, out var piece) ? piece : null;
        }

        public void AddPiece(BasePiece piece)
        {
            BoardIdsDict.TryAdd(piece.Id.ToString(), piece);
            BoardPositionsDict.TryAdd(piece.Position, piece);
        }

        public void RemovePiece(BasePiece piece)
        {
            BoardIdsDict.Remove(piece.Id.ToString());
            BoardPositionsDict.Remove(piece.Position);
        }

        private void InitalizeBoard()
        {
            List<BasePiece> pieces =
            [
                // 2x Black Bishops
                PiecesFactory.CreatePiece(Type.bishop, Color.b, Constants.BlackBishopInitialPosition),
                PiecesFactory.CreatePiece(Type.bishop, Color.b, Constants.BlackBishopInitialPosition),

                // 2x White Bishops
                PiecesFactory.CreatePiece(Type.bishop, Color.w, Constants.WhiteBishopInitialPosition),
                PiecesFactory.CreatePiece(Type.bishop, Color.w, Constants.WhiteBishopInitialPosition with { X = 2 }),

                // Black King
                PiecesFactory.CreatePiece(Type.king, Color.b, Constants.BlackKingInitialPosition),

                // White King
                PiecesFactory.CreatePiece(Type.king, Color.w, Constants.WhiteKingInitialPosition),

                // 2x Black Knight
                PiecesFactory.CreatePiece(Type.knight, Color.b, Constants.BlackKnightInitialPosition),
                PiecesFactory.CreatePiece(Type.knight, Color.b, Constants.BlackKnightInitialPosition with { X = 6 }),

                // 2x White Knight
                PiecesFactory.CreatePiece(Type.knight, Color.w, Constants.WhiteKnightInitialPosition),
                PiecesFactory.CreatePiece(Type.knight, Color.w, Constants.WhiteKnightInitialPosition with { X = 1 }),

                // 8x Black Pawns
                ..Enumerable
                    .Range(0, SIZE)
                    .Select(x => PiecesFactory.CreatePiece(
                        Type.pawn,
                        Color.b,
                        Constants.BlackPawnInitialPosition with { X = x }))
                    .ToList(),

                // 8x White Pawns
                ..Enumerable
                    .Range(0, SIZE)
                    .Select(x => PiecesFactory.CreatePiece(
                        Type.pawn,
                        Color.w,
                        Constants.WhitePawnInitialPosition with { X = x }))
                    .ToList(),

                // Black Queen
                PiecesFactory.CreatePiece(Type.queen, Color.b, Constants.BlackQueenInitialPosition),

                // White Queen
                PiecesFactory.CreatePiece(Type.queen, Color.w, Constants.WhiteQueenInitialPosition),

                // 2x Black Rook
                PiecesFactory.CreatePiece(Type.rook, Color.b, Constants.BlackRookInitialPosition),
                PiecesFactory.CreatePiece(Type.rook, Color.b, Constants.BlackRookInitialPosition with { X = 7 }),

                // 2x White Rook
                PiecesFactory.CreatePiece(Type.rook, Color.w, Constants.WhiteRookInitialPosition),
                PiecesFactory.CreatePiece(Type.rook, Color.w, Constants.WhiteRookInitialPosition with { X = 0 }),
            ];

            pieces
                .Where(piece => piece?.Id != null)
                .ToList()
                .ForEach(piece => {
                    BoardIdsDict.TryAdd(piece.Id.ToString(), piece);
                    BoardPositionsDict.TryAdd(piece.Position, piece);
                });
        }
    }
}
