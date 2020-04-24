using System;
using System.Threading.Tasks;
using UserService.Models;

namespace AuthenticationService.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Hashes password and saves this to the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="password">unhashed password</param>
        /// <returns>nothing</returns>
        Task InsertRegisteredUser(Guid id, string email, string password);
    }
}