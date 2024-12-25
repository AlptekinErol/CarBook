using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BrandCommands
{
    public class UpdateBrandCommand : IRequest
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
