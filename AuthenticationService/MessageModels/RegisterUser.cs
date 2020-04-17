using System;

namespace AuthenticationService.Models
{
    public class RegisterUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}