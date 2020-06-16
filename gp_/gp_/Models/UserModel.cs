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
       

    }
}
