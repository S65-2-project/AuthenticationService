using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuthenticationService.Helpers;
using AuthenticationService.Repositories;
using AuthenticationService.Services;
using Moq;
using Xunit;

namespace AuthenticationServiceTest.Services
{
    public class UserServiceTest
    {
        private Mock<IUserRepository> _repo;
        private IHasher _hasher;
        public void Setup()
        {
            _repo = new Mock<IUserRepository>();
        }
        [Fact]
        public void InsertRegisteredUserTest_Succesfull()
        {
            Guid id = new Guid();
            string email = "ik.ben@mail.com";
            string password = "ASH!#hdjasf";
            _hasher = new AuthenticationService.Helpers.Hasher();
        }
    }
}
