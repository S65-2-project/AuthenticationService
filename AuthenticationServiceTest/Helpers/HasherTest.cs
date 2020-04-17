using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AuthenticationService.Helpers;
using Xunit.Sdk;

namespace AuthenticationServiceTest.Hasher
{
    public class HasherTest
    {
        private IHasher _hasher;
        
        
        public void setup()
        {
            _hasher = new AuthenticationService.Helpers.Hasher();
        }

        [Fact]
        public void Verify_Password_Correct()
        {
            var salt = _hasher.CreateSalt();
            string pass = "Testpass";
            var hash = _hasher.HashPassword(pass, salt);
            Assert.True(_hasher.VerifyHash(pass, salt,hash.Result).Result);
        }

        [Fact]
        public void Verify_Password_Incorrect_Password()
        {
            var salt = _hasher.CreateSalt();
            string pass = "Testpass";
            string wrongpass = "wrongpass";
            var hash = _hasher.HashPassword(pass, salt);
            Assert.False(_hasher.VerifyHash(wrongpass, salt,hash.Result).Result);
        }

        [Fact]
        public void Verify_Password_Incorrect_Salt()
        {
            var salt = _hasher.CreateSalt();
            string pass = "Testpass";
            var wrongsalt = _hasher.CreateSalt();
            var hash = _hasher.HashPassword(pass, salt);
            Assert.False(_hasher.VerifyHash(pass, wrongsalt, hash.Result).Result);
        }
    }
}
