using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class UpdateFooterAddressCommand : IRequest
    {
        public int FooterAddressId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
