using Microsoft.AspNetCore.Mvc;
using NETChessGame.Server.Dto.error;

namespace NETChessGame.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController(ILogger logger) : ControllerBase
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet]
        [ProducesResponseType<String>(StatusCodes.Status200OK)]
        protected IActionResult Get()
        {
            return Ok("Status: OK");
        }

        [ProducesErrorResponseType(typeof(ErrorResponse))]
        protected IActionResult OnError(int errorCode, string errorMessage, Dictionary<string, object>? errorDetails)
        {
            var errorResponse = new ErrorResponse(errorCode, errorMessage, errorDetails);

            _logger.LogError("Error {ErrorCode} - {ErrorMessage}", errorCode, errorMessage);
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}
