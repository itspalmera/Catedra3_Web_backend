using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Interfaces;
using api.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.src.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        // GET ALL BLOGS
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs(){
            
            var blogs = await _blogRepository.GetAllBlogs();

            return Ok(blogs);
        }

        /*
        // GET BLOG BY ID
        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            var blog = _blogRepository.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }   
        */

        // CREATE
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] Blog blog){
            try
            {
                var newBlog = await _blogRepository.CreateBlog(blog);
                return Ok(newBlog);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

    }
}