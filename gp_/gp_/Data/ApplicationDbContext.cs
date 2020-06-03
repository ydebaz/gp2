using System;
using System.Collections.Generic;
using System.Text;
using gp_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gp_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserModel> user { get; set; }
        public DbSet<DoctorModel> doctor { get; set; }
    }
}
