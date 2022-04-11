using System;

namespace Telegram.Model
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeleteDate { get; set; }

    }
}
