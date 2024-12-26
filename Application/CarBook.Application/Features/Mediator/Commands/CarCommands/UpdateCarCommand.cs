using CarBook.Common.Enums;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarCommands
{
    public class UpdateCarCommand : IRequest
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string Km { get; set; }
        public Transmission Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
