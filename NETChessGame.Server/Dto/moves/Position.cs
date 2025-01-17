using System.ComponentModel.DataAnnotations;
using static NETChessGame.Server.Utils.Constants;

namespace NETChessGame.Server.Dto.moves
{
    public class PositionDto(int x, int y)
    {
        [Required, Range(0, MAX_BOARD_SIZE - 1)]
        public int X { get; set; } = x;

        [Required, Range(0, MAX_BOARD_SIZE - 1)]
        public int Y { get; set; } = y;
    }
}
