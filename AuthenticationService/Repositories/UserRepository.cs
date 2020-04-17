using MongoDB.Driver;

namespace AuthenticationService.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _users;
    }
}