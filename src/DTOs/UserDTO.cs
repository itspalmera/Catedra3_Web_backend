using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Models;

namespace api.src.DTOs
{
    public class UserDTO
    {
        public required string Email { get; set; }
        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }
}