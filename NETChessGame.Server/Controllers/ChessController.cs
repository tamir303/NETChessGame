using Microsoft.AspNetCore.Mvc;
using NETChessGame.Server.Dto;
using NETChessGame.Server.Dto.error;
using NETChessGame.Server.Dto.moves;
using NETChessGame.Server.Dto.state;
using NETChessGame.Server.Logic.Manager;
using static NETChessGame.Server.Dto.moves.ModelControllerConverter;


namespace NETChessGame.Server.Controllers
{
    [Route("/v1/[controller]")]
    [ApiController]
    public partial class ChessController(ILogger<ChessController> logger) : ApiController(logger)
    {
        [HttpGet]
        [ProducesResponseType<StateResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromServices] IModel model)
        {
            try
            {
                var pieceList = ConvertToChessPieceList(model.GetCurrentState());
                return Ok(new StateResponse(success: true, message: "Fetch pieces", pieces: pieceList));
            }
            catch (Exception ex)
            {
                return OnError(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while processing the request",
                    new Dictionary<string, object> {
                        { "Exception", ex.Message }
                    });
            }
        }


        [HttpPost("/move")]
        [ProducesResponseType<MoveResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<BaseResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        public IActionResult Move([FromBody] MoveRequest request)
        {
            try
            {
                if (String.IsNullOrEmpty(request.Id))
                    return BadRequest(new BaseResponse(false, "Id is required"));

                return Ok(
                    new MoveResponse(
                        true,
                        "Move successful",
                        new Dictionary<string, object> {
                            { "Id", request.Id },
                            { "OldPosition", request.Position }
                }));
            }
            catch (Exception ex)
            {
                return OnError(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while processing the request",
                    new Dictionary<string, object> {
                        { "Exception", ex.Message }
                    });
            }
        }
    }
}
