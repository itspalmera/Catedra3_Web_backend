using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Data;
using api.src.Interfaces;
using api.src.Models;

namespace api.src.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        
        public BlogRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET ALL BLOGS
        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return await Task.FromResult(_dbcontext.Blogs);
        }

        // GET BLOG BY ID
        public async Task<Blog> GetBlogById(int id)
        {
            return await Task.FromResult(_dbcontext.Blogs.Find(id));
        }

        // CREATE
        public async Task<Blog> CreateBlog(Blog blog)
        {
            _dbcontext.Blogs.Add(blog);
            await _dbcontext.SaveChangesAsync();
            return blog;
        }

        
    }
}