using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.Models
{
    public class Blog
    {
        public required int BlogId { get; set; }
        public required string Title { get; set; }
        public required DateTime Date { get; set; }
        public required string ImageUrl { get; set; }
        // relacion con usuario
        public required int UserId { get; set; }
        public required User User { get; set; }
    }
}