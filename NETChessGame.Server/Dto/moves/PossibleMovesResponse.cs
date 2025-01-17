
namespace NETChessGame.Server.Dto.moves
{
    public class PossibleMovesResponse : MoveResponse
    {
        public PossibleMovesResponse(bool success) : base(success)
        {
        }

        public PossibleMovesResponse(bool success, string message) : base(success, message)
        {
        }

        public PossibleMovesResponse(bool success, string message, Dictionary<string, object> data) : base(success, message, data)
        {
        }
    }
}
