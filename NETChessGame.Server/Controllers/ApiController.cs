using Microsoft.AspNetCore.Mvc;
using NETChessGame.Server.Dto.error;

namespace NETChessGame.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController(ILogger logger) : ControllerBase
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [ProducesErrorResponseType(typeof(ErrorResponse))]
        protected IActionResult OnError(int errorCode, string errorMessage, Dictionary<string, object>? errorDetails)
        {
            var errorResponse = new ErrorResponse(errorCode, errorMessage, errorDetails);

            _logger.LogError("Error {ErrorCode} - {ErrorMessage}", errorCode, errorMessage);
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}
