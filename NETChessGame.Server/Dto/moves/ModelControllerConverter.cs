using NETChessGame.Server.Dto.state;
using NETChessGame.Server.Logic.Board.Pieces.Impl;

namespace NETChessGame.Server.Dto.moves
{
    public abstract class ModelControllerConverter
    {
        public static ChessPiece ConvertToChessPiece(BasePiece piece)
        {
            return new ChessPiece(
                id: piece.Id,
                type: piece.Name.Split("-")[0],
                color: piece.Name.Split("-")[1],
                position: new PositionDto(piece.Position.X, piece.Position.Y)
            );
        }

        public static IEnumerable<ChessPiece> ConvertToChessPieceList(IEnumerable<BasePiece> pieces)
        {
            return pieces.Select(ConvertToChessPiece);
        }
    }
}
