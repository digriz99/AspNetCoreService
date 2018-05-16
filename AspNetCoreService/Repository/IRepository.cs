using AspNetCoreService.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreService.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Add User
        /// </summary>
        /// <returns></returns>
        Task<List<UserModel>> GetUsers();

        /// <summary>
        /// Create New User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<UserModel> CreateUser(UserModel user);

        /// <summary>
        /// Update Existing User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> UpdateUser(UserModel user);

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUser(Guid id);
    }
}
