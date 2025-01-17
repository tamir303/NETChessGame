
namespace NETChessGame.Server.Dto.moves
{
    public class MoveResponse : BaseResponse
    {
        public MoveResponse(bool success) : base(success)
        {
        }

        public MoveResponse(bool success, string message) : base(success, message)
        {
        }

        public MoveResponse(bool success, string message, Dictionary<string, object> data) : base(success, message, data)
        {
        }
    }
}
