using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreService.Repository;
using AspNetCoreService.Repository.Models;

namespace AspNetCoreService.Controllers
{
    [Route("api/core")]
    public class CoreController : Controller
    {
        private IRepository _repository;

        public CoreController(IRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [Route("GetUsers"), HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _repository.GetUsers());
        }
        
        /// <summary>
        /// Create New User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("CreateUser"), HttpPut]
        public async Task<IActionResult> CreateUser([FromBody]UserModel user)
        {
            if (user == null) return BadRequest();
            var created = await _repository.CreateUser(user);

            return Created(created.Id.ToString(), created);
        }
        
        /// <summary>
        /// Update User Date
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("UpdateUser"), HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody]UserModel user)
        {
            if (user == null) return BadRequest();

            var result = await _repository.UpdateUser(user);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        /// <summary>
        /// Delete Existing USer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteUser"), HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _repository.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
