﻿using Microsoft.EntityFrameworkCore;
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
    }
}