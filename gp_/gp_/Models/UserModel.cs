using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gp_.Models
{
    public class UserModel //: IdentityUser
    {
        public Guid Id { get; set; }
        [Required()]
        public string FirstName { get; set; }

        [Required()]
        public string LastName { get; set; }
        [Required(),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(),DataType(DataType.Password)]
        public string password { get; set; }
        public bool IsEmailConfirmed { get; set; } 
        [DataType(DataType.DateTime)]
        public System.DateTime? EmailConfirmationDate { get; set; }
       // public int Score { get; set; }
      
    }
}
