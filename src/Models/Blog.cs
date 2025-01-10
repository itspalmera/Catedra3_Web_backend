using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.src.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        // relacion con usuario
        public string UserId { get; set; }
        public User User { get; set; }
    }
}