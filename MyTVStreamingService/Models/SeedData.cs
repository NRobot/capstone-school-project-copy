using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MyTVStreamingService.Data;

namespace MyTVStreamingService.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyTVContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyTVContext>>()))
            {
                // Seed Show table if it is empty
                if (!context.Show.Any())
                {
                    context.Show.AddRange(
                        new Show
                        {
                            Title = "Game of Thrones",
                            ReleaseDate = DateTime.Parse("2011-4-17"),
                            Genre = "Action",
                            NumberOfSeasons = 8,
                            Rating = 9.4
                        },

                        new Show
                        {
                            Title = "The Simpsons",
                            ReleaseDate = DateTime.Parse("1989-12-17"),
                            Genre = "Comedy",
                            NumberOfSeasons = 32,
                            Rating = 8.7
                        },

                        new Show
                        {
                            Title = "The Office",
                            ReleaseDate = DateTime.Parse("2005-3-24"),
                            Genre = "Comedy",
                            NumberOfSeasons = 9,
                            Rating = 8.8
                        },

                        new Show
                        {
                            Title = "The Walking Dead",
                            ReleaseDate = DateTime.Parse("2010-10-31"),
                            Genre = "Thriller",
                            NumberOfSeasons = 10,
                            Rating = 8.3
                        },

                        new Show
                        {
                            Title = "Euphoria",
                            ReleaseDate = DateTime.Parse("2019-6-16"),
                            Genre = "Drama",
                            NumberOfSeasons = 1,
                            Rating = 8.4
                        }
                    );
                }
                // Seed User table if it is empty
                if(!context.User.Any())
                {
                    context.User.AddRange(
                        new User
                        {
                            UserName = "nRoberts2020",
                            UserPassword = "123456789",
                            FirstName = "Nathan",
                            LastName = "Roberts",
                            EmailAddress = "NR@mytvadmin.com",
                            AccCreationDate = DateTime.Parse("2016-4-11")
                        },

                        new User
                        {
                            UserName = "bobBobbington",
                            UserPassword = "234567891",
                            FirstName = "Bob",
                            LastName = "Smith",
                            EmailAddress = "bobsmith@tacos.com",
                            AccCreationDate = DateTime.Parse("2019-1-8")
                        },

                        new User
                        {
                            UserName = "batman4ever1955",
                            UserPassword = "345678912",
                            FirstName = "Bat",
                            LastName = "Man",
                            EmailAddress = "batman@batcave.com",
                            AccCreationDate = DateTime.Parse("2018-4-24")
                        }
                    );
                }

                // context.Show.AddRange(
                //     new Show
                //     {
                //         Title = "Game of Thrones",
                //         ReleaseDate = DateTime.Parse("2011-4-17"),
                //         Genre = "Action",
                //         NumberOfSeasons = 8,
                //         Rating = 9.4
                //     },

                //     new Show
                //     {
                //         Title = "The Simpsons",
                //         ReleaseDate = DateTime.Parse("1989-12-17"),
                //         Genre = "Comedy",
                //         NumberOfSeasons = 32,
                //         Rating = 8.7
                //     },

                //     new Show
                //     {
                //         Title = "The Office",
                //         ReleaseDate = DateTime.Parse("2005-3-24"),
                //         Genre = "Comedy",
                //         NumberOfSeasons = 9,
                //         Rating = 8.8
                //     },

                //     new Show
                //     {
                //         Title = "The Walking Dead",
                //         ReleaseDate = DateTime.Parse("2010-10-31"),
                //         Genre = "Thriller",
                //         NumberOfSeasons = 10,
                //         Rating = 8.3
                //     },

                //     new Show
                //     {
                //         Title = "Euphoria",
                //         ReleaseDate = DateTime.Parse("2019-6-16"),
                //         Genre = "Drama",
                //         NumberOfSeasons = 1,
                //         Rating = 8.4
                //     }
                // );
                context.SaveChanges();
            }
        }
    }
}