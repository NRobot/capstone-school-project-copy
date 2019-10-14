using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyTVStreamingService.Models
{
    public class MyTVStreamingServiceContext : DbContext
    {
        public MyTVStreamingServiceContext (DbContextOptions<MyTVStreamingServiceContext> options)
            : base(options)
        {
        }

        public DbSet<MyTVStreamingService.Models.AdminService> AdminService { get; set; }
        public DbSet<MyTVStreamingService.Models.AdminNetwork> AdminNetwork { get; set; }
    }
}
