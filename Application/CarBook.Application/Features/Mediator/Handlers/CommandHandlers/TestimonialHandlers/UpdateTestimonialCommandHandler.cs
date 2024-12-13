using CarBook.Application.Features.Mediator.Commands.TestimonialCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> repository;
        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.TestimonialId);
            data.Comment = request.Comment;
            data.Title = request.Title;
            data.Name = request.Name;
            data.ImageUrl = request.ImageUrl;
            data.CreatedDate = request.CreatedDate;
            data.UpdatedDate = DateTime.UtcNow;      
            await repository.UpdateAsync(data);
        }
    }
}
