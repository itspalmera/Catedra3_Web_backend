using System;

using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace api.src.Models
{
    public class User : IdentityUser
    {
        //public required int UserId { get; set; }
        //public required new string Email { get; set; }
        //public required string Password { get; set; }


        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }
}