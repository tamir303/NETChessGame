using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NETChessGame.Server.Dto
{
    public class BaseResponse
    {
        [Required]
        public Boolean Success { get; set; }

        [Required, StringLength(50)]
        public String Message { get; set; }

        [JsonPropertyName("Data")]
        public Dictionary<string, object>? Data { get; set; }

        public BaseResponse(bool success, string message, Dictionary<string, object> data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
            Data = null;
        }

        public BaseResponse(bool success)
        {
            Success = success;
            Message = String.Empty;
            Data = null;
        }
    }
}
