using System;
using Microsoft.EntityFrameworkCore;

namespace UserService.Models
{
    public class USContext : DbContext
    {
        public USContext(DbContextOptions<USContext> opt) : base(opt) { }

        public DbSet<userModel> userModels { get; set; }
    }
}
