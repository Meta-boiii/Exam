using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDeal.Data.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }

        public List<UserType> userTypes { get; set; } = new List<UserType>();

    }
}
