using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Models;

namespace api.src.Interfaces
{
    public interface IUserRepository
    {
        
        public Task<User> GetUserById(string id);
        

        public Task<User> GetUserByEmail(string email);
        

        public Task<User> AddUser(User user);
    }
}