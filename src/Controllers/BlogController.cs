using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.DTOs;
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
        private readonly IUserRepository _userRepository;
        public BlogController(IBlogRepository blogRepository, IUserRepository userRepository)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
        }

        // GET ALL BLOGS
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs(){
            
            var blogs = await _blogRepository.GetAllBlogs();


            // si no hay post
            if (blogs == null || blogs.Count() == 0)
            {
                return Ok(new { Message = "No hay posts" });
            }
            

            var blogsDTOs = new List<BlogDTO>();

            foreach (var blog in blogs)
            {
                var blogDTO = new BlogDTO
                {
                    Title = blog.Title,
                    Date = blog.Date,
                    ImageUrl = blog.ImageUrl,
                    Email = blog.User.Email
                };

                blogsDTOs.Add(blogDTO);
            }

            return Ok(blogsDTOs);
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
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogDTO blogDTO){
            if (blogDTO.Email == null || blogDTO.Email == "")
            {
                return BadRequest("El correo esta vacio.");
            }

            var user = await _userRepository.GetUserByEmail(blogDTO.Email);
            if (user == null)
            {
                return BadRequest("El usuario no existe.");
            }
            
            // AQUI SUBIR UNA IMAGEN DE CLUIDINARY CON EL CLOUDINARY SERVICE

            string imageUrl;

            // Crear un Blog con blogDTO
            var blog = new Blog
            {
                Title = blogDTO.Title,
                Date = DateTime.Now,
                ImageUrl = blogDTO.ImageUrl,
                UserId = user.Id,
                User = user
            };

            
            // Crear un Blog en la Base de datos
            //var newBlog = await _blogRepository.CreateBlog(blog);

            // Retornar el Blog al Usuario

            await _blogRepository.CreateBlog(blog);
            return CreatedAtAction(nameof(GetAllBlogs), new { id = blog.BlogId }, blog);
            
            
        }
        

    }
}