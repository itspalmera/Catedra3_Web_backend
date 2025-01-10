using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.DTOs
{
    public class BlogDTO
    {
        public required string Title { get; set; }
        public required DateTime Date { get; set; }
        public required string ImageUrl { get; set; }
        // relacion con usuario
        public required string Email { get; set; }
    }
}