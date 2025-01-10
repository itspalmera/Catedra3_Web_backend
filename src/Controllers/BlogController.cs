using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Interfaces;
using api.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        // GET ALL BLOGS
        [HttpPost]
        public async Task<IActionResult> GetAllBlogs(){
            
            var users = await _blogRepository.GetAllBlogs();

            return Ok(users);
        }


        // GET BLOG BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id){
            try
            {
                var blog = await _blogRepository.GetBlogById(id);
                return Ok(blog);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

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