using System;

namespace DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Salt { get; set; }
        public string Role { get; set; }
    }
}
