using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplaceJsonFormatter.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }

        public Gender Gender { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
