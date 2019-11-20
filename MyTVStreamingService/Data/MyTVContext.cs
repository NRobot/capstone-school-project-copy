using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyTVStreamingService.Models;

namespace MyTVStreamingService.Data
{
    public class MyTVContext : IdentityDbContext<MyTVUser>
    {
        public MyTVContext(DbContextOptions<MyTVContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyTVUser>().ToTable("AspNetUsers");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Show> Show { get; set; }
        public DbSet<ShowService> ShowService{get;set;}
        public DbSet<Service> Service { get; set; }
        public DbSet<AdminHelpdesk> AdminHelpdesk { get; set; }
    }
}