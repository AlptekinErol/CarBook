using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> repository;
        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        /// <summary>
        ///  Mantık olarak önce data içerisine command (request) ile id sayesinde ilgili veri geliyor 
        ///  sonrasında data yani Db den gelen veri command (request) ile update ediliyor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.CategoryId);
            data.UpdatedDate = DateTime.Now;
            data.CreatedDate = request.CreatedDate;
            data.Name = request.Name;
            await repository.UpdateAsync(data);
        }
    }
}
