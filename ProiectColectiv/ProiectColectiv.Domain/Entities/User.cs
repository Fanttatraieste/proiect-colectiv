using ProiectColectiv.Domain.Enums;
using System;

namespace ProiectColectiv.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
