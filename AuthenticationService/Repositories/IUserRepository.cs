using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace AuthenticationService.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Returns a list of users
        /// </summary>
        /// <returns></returns>
        Task<List<User>> Get();

        /// <summary>
        /// Returns a user with a specefied Email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> Get(string email);

        /// <summary>
        /// Returns a user with a specefied Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> Get(Guid id);

        /// <summary>
        /// Creates a User using a user object
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> Create(User user);
        /// <summary>
        /// Updates the records of a user with a specefied ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userIn"></param>
        /// <returns></returns>
        Task Update(Guid id, User userIn);

        /// <summary>
        /// Removes a user matching the user object from the database
        /// </summary>
        /// <param name="userIn"></param>
        void Remove(User userIn);
        
        /// <summary>
        /// Removes a user matching the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Remove(Guid id);
    }
}