using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> repository;
        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateCategoryCommand command)
        {
            await repository.CreateAsync(new Category
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Name = command.Name,
            });
        }
    }
}
