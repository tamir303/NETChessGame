using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static NETChessGame.Server.Utils.Constants;

namespace NETChessGame.Server.Dto.state
{
    public class StateResponse : BaseResponse
    {
        [Required, Length(maximumLength: MAX_PIECES, minimumLength: MIN_PIECES), DisallowNull]
        public IEnumerable<ChessPiece> Pieces { get; set; }

        public StateResponse(bool success, string message, IEnumerable<ChessPiece> pieces) 
            : base(success, message)
        {
            Data = new Dictionary<string, object>()
            {
                { "Pieces", pieces }
            };
        }
    }
}
