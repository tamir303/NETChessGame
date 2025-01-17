namespace ChessGame.Models.Command;

using System.Numerics;
using NETChessGame.Server.Logic.Board;
using NETChessGame.Server.Logic.Board.Pieces.Enums;
using NETChessGame.Server.Logic.Board.Pieces.Impl;
using NETChessGame.Server.Logic.Command;

public class MoveCommand(GameBoard board, BasePiece piece, Position to) : ICommand
{
    private readonly GameBoard _board = board;
    private readonly BasePiece _piece = piece;
    private readonly Position _to = to;
    private readonly Position _from = piece.Position;
    private BasePiece? _capturedPiece = null;

    public void Execute()
    {
        _capturedPiece = _board.GetPieceByPosition(new(_to.X,_to.Y));
        var currentAction = _capturedPiece != null ? Actions.Eat : Actions.None;
        
        if (!_piece.MoveTo(_to, currentAction))
            throw new Exception("Invalid move");
        
        if (_capturedPiece != null)
            _board.RemovePiece(_capturedPiece);
    }

    public void Undo()
    {
        _piece.Position = _from;
        if (_capturedPiece?.Name != null) 
            _board.AddPiece(_capturedPiece);
    }
}