using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
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
        public async Task Handle(UpdateCategoryCommand command)
        {
            var data = await repository.GetByIdAsync(command.CategoryId);
            data.UpdatedDate = DateTime.Now;
            data.CreatedDate = command.CreatedDate;
            data.Name = command.Name;
            await repository.UpdateAsync(data);
        }
    }
}
