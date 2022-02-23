using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.Models
{
    public class UserModel
    {
        
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public string PhoneNumber { get; set; }
            public string ContextMoc { get; set; }
            public string Date { get; set; }
        
    }
}
