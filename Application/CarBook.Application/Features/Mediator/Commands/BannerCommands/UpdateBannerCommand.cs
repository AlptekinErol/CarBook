using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.BannerCommands
{
    public class UpdateBannerCommand : IRequest
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string VideoDescription { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
