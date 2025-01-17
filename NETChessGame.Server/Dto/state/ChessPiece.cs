using Microsoft.AspNetCore.Mvc;
using NETChessGame.Server.Dto.moves;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NETChessGame.Server.Dto.state
{
    public class ChessPiece(string id, string type, string color, PositionDto position)
    {
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; } = id;

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; } = type;

        [Required(ErrorMessage = "Color is required")]
        public string Color { get; set; } = color;

        [Required(ErrorMessage = "Position is required"), FromBody, DisallowNull]
        public PositionDto Position { get; set; } = position;
    }
}