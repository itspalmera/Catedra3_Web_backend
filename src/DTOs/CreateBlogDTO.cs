using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.DTOs
{
    public class CreateBlogDTO
    {
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }

        public required string Email { get; set; }
    }
}