using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MyTVStreamingService.Data;

namespace MyTVStreamingService.Models
{
    public static class UserSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyTVContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyTVContext>>()))
            {
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        userName = "nRoberts2020",
                        userPassword = "123456789",
						firstName = "Nathan",
						lastName = "Roberts",
						emailAddress = "NR@mytvadmin.com",
						accCreationDate = DateTime.Parse("2016-4-11")
                    },

                   new User
                    {
                        userName = "bobBobbington",
                        userPassword = "234567891",
						firstName = "Bob",
						lastName = "Smith",
						emailAddress = "bobsmith@tacos.com",
						accCreationDate = DateTime.Parse("2019-1-8")
                    },

                   new User
                    {
                        userName = "batman4ever1955",
                        userPassword = "345678912",
						firstName = "Bat",
						lastName = "Man",
						emailAddress = "batman@batcave.com",
						accCreationDate = DateTime.Parse("2018-4-24")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}