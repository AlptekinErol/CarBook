using CarBook.Domain.Entities;
using CarBook.Domain.Enums;

namespace CarBook.Application.Features.CQRS.Commands.CarCommands
{
    public class CreateCarCommand
    {
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string Km { get; set; }
        public Transmission Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
