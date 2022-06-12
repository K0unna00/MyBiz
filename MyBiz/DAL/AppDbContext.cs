using Microsoft.EntityFrameworkCore;
using MyBiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBiz.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) :base(option)
        {

        }
        public DbSet<Position> Positions { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
    }
}
