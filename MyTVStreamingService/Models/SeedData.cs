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
                if (!context.Recommended.Any())
                {
                    context.Recommended.AddRange(
                        new Recommended
                        {
                            userID = 1,
                            show = "Game of Thrones",
                            count = 3
                        },

                        new Recommended
                        {
                            userID = 1,
                            show = "The Simpsons",
                            count = 1
                        }

                        );
                }
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