﻿using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repository.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext carBookContext;
        public BlogRepository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
        }
        /// <summary>
        /// BlogId'ye 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Blog>> GetBlogByAuthorId(int id)
        {
            var data = await carBookContext.Blogs.Include(x => x.Author).Where(y => y.Id == id).ToListAsync(); 
            return data;
        }

        public async Task<List<Blog>> GetBlogsWithAuthor()
        {
            var data = await carBookContext.Blogs.Include(x => x.Author).ToListAsync();
            return data;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthor()
        {
            var data = await carBookContext.Blogs.Include(x => x.Author).OrderByDescending(x => x.Id).Take(3).ToListAsync();
            return data;
        }
    }
}
