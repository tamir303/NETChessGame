using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using NETChessGame.Server.Dto.moves;

namespace NETChessGame.Server.Dto.moves
{
    public class MoveRequest(String Id, PositionDto position)
    {
        [Required]
        public String Id { get; set; } = Id;

        [Required, FromBody]
        public PositionDto Position { get; set; } = position;
    }
}
