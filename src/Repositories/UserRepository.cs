using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Data;
using api.src.Interfaces;
using api.src.Models;
using Microsoft.AspNetCore.Identity;

namespace api.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbcontext;
        
        public UserRepository(ApplicationDbContext dbcontext, UserManager<User> userManager)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
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
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
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