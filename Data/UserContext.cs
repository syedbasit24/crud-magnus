using CRUDMagnus.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUDMagnus.Data
{
    public class UserContext :DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Place> place { get; set; }
    }
}
