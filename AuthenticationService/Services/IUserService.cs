using System;
using System.Threading.Tasks;
using UserService.Models;

namespace AuthenticationService.Services
{
    public interface IUserService
    {
        Task InsertRegisteredUser(Guid id, string email, string password);
    }
}