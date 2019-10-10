using Microsoft.EntityFrameworkCore;
using MyTVStreamingService.Models;

namespace MyTVStreamingService.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options)
            : base(options)
        {
        }
        public DbSet<Service> Service { get; set; }
    }
}