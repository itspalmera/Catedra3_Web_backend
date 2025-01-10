using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Data;
using api.src.Interfaces;
using api.src.Models;

namespace api.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        
        public UserRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await Task.FromResult(_dbcontext.Users.Find(id));

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await Task.FromResult(_dbcontext.Users.FirstOrDefault(u => u.Email == email));

            if (user == null){
                throw new KeyNotFoundException($"User with email {email} not found.");
            }

            return user;
        }

        public async Task<User> AddUser(User user)
        {
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }
    }
}