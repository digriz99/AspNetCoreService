using AspNetCoreService.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreService.Repository
{
    public class Repository : IRepository
    {
        private UsersContext _usersContext;

        public Repository(UsersContext usersContext)
        {
            _usersContext = usersContext;
        }

        public Task<List<UserModel>> GetUsers()
        {
            return _usersContext.Users.ToListAsync();
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            user.Id = Guid.NewGuid();
            _usersContext.Users.Add(user);

            await _usersContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UpdateUser(UserModel user)
        {
            var current = _usersContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (current == null)
            {
                return false;
            }

            current.Name = user.Name;
            current.Surname = user.Surname;
            current.Telephone = user.Telephone;
            current.Address = user.Address;

            await _usersContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var current = _usersContext.Users.FirstOrDefault(u => u.Id == id);
            _usersContext.Users.Remove(current);

            await _usersContext.SaveChangesAsync();
            return true;
        }
    }
}
