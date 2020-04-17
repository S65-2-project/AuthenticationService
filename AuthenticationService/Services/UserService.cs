using System;
using System.Threading.Tasks;
using AuthenticationService.Helpers;
using AuthenticationService.Repositories;
using UserService.Models;

namespace AuthenticationService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IHasher _hasher;

        public UserService(IHasher hasher, IUserRepository repository)
        {
            _hasher = hasher;
            _repository = repository;
        }

        public async Task InsertRegisteredUser(Guid id, string email, string password)
        {

            var salt = _hasher.CreateSalt();
            var hasedPassword = await _hasher.HashPassword(password, salt);
            var user = new User()
            {
                Id = id,
                Email = email,
                Password = hasedPassword,
                Salt = salt
            };
            
            await _repository.Create(user);

        }
    }
}