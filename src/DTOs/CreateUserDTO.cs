using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Models;

namespace api.src.DTOs
{
    public class CreateUserDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}