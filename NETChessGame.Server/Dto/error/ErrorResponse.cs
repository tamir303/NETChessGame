namespace NETChessGame.Server.Dto.error
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public Dictionary<string, object>? ErrorDetails { get; set; }
        public DateTime DateTime { get; set; }

        public ErrorResponse(int errorCode, string errorMessage, Dictionary<string, object>? errorDetails) 
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorDetails = errorDetails;
            DateTime = DateTime.Now;
        }

        public ErrorResponse(int errorCode, string errorMessage) : this(errorCode, errorMessage, null) { }
    }
}
