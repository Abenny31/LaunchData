using LaunchData.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LaunchData.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LaunchModel> LaunchModels { get; set; }
        public DbSet<Fairings> Fairings { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<Failure> Failures { get; set; }
        public DbSet<Core> Cores { get; set; }


    }
}
