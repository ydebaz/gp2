﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp_.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public System.DateTime? EmailConfirmationDate { get; set; }
       // public int Score { get; set; }
    }
}
