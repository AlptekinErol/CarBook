using CarBook.Common.Enums;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarCommands
{
    public class CreateCarCommand : IRequest
    {
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public Transmission Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
