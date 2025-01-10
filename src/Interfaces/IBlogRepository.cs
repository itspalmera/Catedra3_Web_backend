using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Models;

namespace api.src.Interfaces
{
    public interface IBlogRepository
    {
        // GET ALL BLOGS
        public Task<IEnumerable<Blog>> GetAllBlogs();


        // GET BLOG BY ID
        public Task<Blog> GetBlogById(int id);


        // CREATE
        public Task<Blog> CreateBlog(Blog blog);

    }
}