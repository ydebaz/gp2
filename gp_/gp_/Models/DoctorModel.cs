using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace gp_.Models
{
    public class DoctorModel//:  IdentityUser
    {
        public Guid Id { get; set; }
        [Required()]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required()]
        [DataType(DataType.Text)]

        public string LastName { get; set; }
        [Required(), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(), DataType(DataType.Password)]
        public string password { get; set; }
        public bool IsEmailConfirmed { get; set; }
        [DataType(DataType.DateTime)]
        public System.DateTime? EmailConfirmationDate { get; set; }

        public string graduation_uni { get; set; }

        public bool isActivated { get; set; }

        public string workplace { get; set; }
        public string status { get; set; }
        [NotMapped]
        public Image Portrait { get; set; }
        [NotMapped]
        public Image proofofwork { get; set; }

        public int personalphonenumber { get; set; }
        public int workphonenumber { get; set; }

        public bool ispart1comp { get; set; }

        public int jma_number { get; set; }
        // public int Score { get; set; }
    }
}
