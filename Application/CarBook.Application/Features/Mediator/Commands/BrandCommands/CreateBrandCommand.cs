using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BrandCommands
{
    public class CreateBrandCommand : IRequest
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
