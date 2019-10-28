using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyTVStreamingService.Data;

namespace MyTVStreamingService.Models
{
    public class SeedRecommended
    {
        public static void IntializeRecommended(IServiceProvider serviceProvider)
        {
            using (var context = new MyTVContext(serviceProvider.GetRequiredService<DbContextOptions<MyTVContext>>()))
            {
                if (context.Recommended.Any())
                {
                    return;
                }
                context.Recommended.AddRange(
                    new Recommended
                    {
                        userID = 1,
                        recommendedshow = "Game of Thrones",
                        count = 1
                    },
                    new Recommended
                    {
                        userID = 1,
                        recommendedshow = "The Simpsons",
                        count = 3
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
