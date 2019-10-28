using Microsoft.EntityFrameworkCore;
using MyTVStreamingService.Models;

namespace MyTVStreamingService.Data
{
    public class MyTVContext : DbContext
    {
        public MyTVContext(DbContextOptions<MyTVContext> options)
            : base(options)
        {
        }
        public DbSet<Show> Show { get; set; }

        public DbSet<Recommendation> Recommendation { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<AdminHelpdesk> AdminHelpdesk { get; set; }
        public DbSet<Recommended> Recommended { get; set; }
    }
}