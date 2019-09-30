using System;

namespace MusicPlay.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PasswordAttempts { get; set; }
        public bool IsActive { get; set; }
    }
}