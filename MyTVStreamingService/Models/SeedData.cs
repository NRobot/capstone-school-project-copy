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

                if (!context.Service.Any())
                {
                    context.Service.AddRange(
                    new Service
                    {
                        ID = 1,
                        name = "Sling Orange",
                        cost = 15
                    },
                    new Service
                    {
                        ID = 2,
                        name = "Sling Blue",
                        cost = 15
                    },
                    new Service
                    {
                        ID = 3,
                        name = "Sling Blue + Orange",
                        cost = 25
                    },

                    new Service
                    {
                        ID = 4,
                        name = "Directtv Now Plus", // new name is AT&T tv now
                        cost = 50
                    },
                    new Service
                    {
                        ID = 5,
                        name = "Directtv Now Max", // new name is AT&T tv now
                        cost = 70
                    },

                    new Service
                    {
                        ID = 6,
                        name = "Playstation Vue Access",
                        cost = 49.99
                    },
                    new Service
                    {
                        ID = 7,
                        name = "Playstation Vue Core",
                        cost = 54.99
                    },

                    new Service
                    {
                        ID = 8,
                        name = "Hulu Live TV",
                        cost = 44.99
                    },

                    new Service
                    {
                        ID = 9,
                        name = "YouTube TV",
                        cost = 49.99
                    }

                    );
                }

                if (!context.Show.Any())
                {
                    context.Show.AddRange(
                        new Show
                        {
                            Id = 1,
                            Title = "SportsCenter",                     // ESPN --> Sling Orange, Playstation Vue Access, Hulu Live TV, Youtube TV
                            ReleaseDate = DateTime.Parse("1979-09-7"),
                            Genre = "Sports",
                            NumberOfSeasons = 39,
                            Rating = 8.2
                        },
                        new Show
                        {
                            Id = 2,
                            Title = "Monday Night Football",            // ESPN --> Sling Orange, Playstation Vue Access, Hulu Live TV, Youtube TV
                            ReleaseDate = DateTime.Parse("1970-09-21"),
                            Genre = "Sports",
                            NumberOfSeasons = 1,
                            Rating = 8.6
                        },
                        new Show
                        {
                            Id = 3,
                            Title = "Hannah Montana",                   // Disney --> Sling Orange, Playstation Vue Access, Hulu Live Tv, Youtube Tv
                            ReleaseDate = DateTime.Parse("2006-03-24"),
                            Genre = "Teen Sitcom",
                            NumberOfSeasons = 4,
                            Rating = 4.9
                        },
                        new Show
                        {
                            Id = 4,
                            Title = "Kim Possible",                     // Disney --> Sling Orange, Playstation Vue Access, Hulu Live Tv, Youtube Tv
                            ReleaseDate = DateTime.Parse("2002-06-07"),
                            Genre = "Action Fiction",
                            NumberOfSeasons = 4,
                            Rating = 7.2
                        },
                        new Show
                        {
                            Id = 5,
                            Title = "Live PD",                          // A&E --> Sling Orange, Hulu Live Tv
                            ReleaseDate = DateTime.Parse("2016-10-28"),
                            Genre = "Reality Television",
                            NumberOfSeasons = 4,
                            Rating = 8.3
                        },
                        new Show
                        {
                            Id = 6,
                            Title = "Intervention",                     // A&E --> Sling Orange, Hulu Live Tv
                            ReleaseDate = DateTime.Parse("2005-03-06"),
                            Genre = "Documentary",
                            NumberOfSeasons = 20,
                            Rating = 7.9
                        },
                        new Show
                        {
                            Id = 7,
                            Title = "Animal Kingdom",                   // TNT --> Sling Orange, Direct Tv Plus, Playstation Vue Access
                            ReleaseDate = DateTime.Parse("2016-06-14"),
                            Genre = "Drama",
                            NumberOfSeasons = 4,
                            Rating = 8.2
                        },
                        new Show
                        {
                            Id = 8,
                            Title = "Cold Justice",                     // TNT --> Sling Orange, Direct Tv Plus, Playstation Vue Access
                            ReleaseDate = DateTime.Parse("2013-09-03"),
                            Genre = "True Crime",
                            NumberOfSeasons = 5,
                            Rating = 7.9
                        },
                        new Show
                        {
                            Id = 9,
                            Title = "The Walking Dead",                 // AMC --> Sling Orange, Playstation Vue Access, Youtube Tv
                            ReleaseDate = DateTime.Parse("2010-10-31"),
                            Genre = "Thriller",
                            NumberOfSeasons = 10,
                            Rating = 8.3
                        },
                        new Show
                        {
                            Id = 10,
                            Title = "The Terror",                       // AMC --> Sling Orange, Playstation Vue Access, Youtube Tv
                            ReleaseDate = DateTime.Parse("2018-03-25"),
                            Genre = "Drama",
                            NumberOfSeasons = 2,
                            Rating = 8
                        },

                        new Show
                        {
                            Id = 11,
                            Title = "Suits",                            // USA --> Sling Blue, Direct Tv Plus, Playstation Vue Core
                            ReleaseDate = DateTime.Parse("2011-06-23"),
                            Genre = "Legal Drama",
                            NumberOfSeasons = 9,
                            Rating = 8.5
                        },

                        new Show
                        {
                            Id = 12,
                            Title = "Mr. Robot",                        // USA --> Sling Blue, Direct Tv Plus
                            ReleaseDate = DateTime.Parse("2015-06-24"),
                            Genre = "Drama",
                            NumberOfSeasons = 5,
                            Rating = 8.5
                        },

                        new Show
                        {
                            Id = 13,
                            Title = "CNN Newsroom",                        // CNN --> Sling Blue, Direct Tv Plus, Playstation Vue Access, Hulu Live Tv, Youtube Tv
                            ReleaseDate = DateTime.Parse("2006-09-04"),
                            Genre = "News Program",
                            NumberOfSeasons = 4,
                            Rating = 3.2
                        },

                        new Show
                        {
                            Id = 14,
                            Title = "Anderson Cooper 360",                 // CNN --> Sling Blue, Direct Tv Plus, Playstation Vue Access, Hulu Live Tv, Youtue Tv
                            ReleaseDate = DateTime.Parse("2003-09-08"),
                            Genre = "Talk Show",
                            NumberOfSeasons = 17,
                            Rating = 5.3
                        },

                        new Show
                        {
                            Id = 15,
                            Title = "The Real Housewives of Orange County", // Bravo --> Sling Blue, Direct Tv Plus, Hulu Live Tv, Youtube Tv
                            ReleaseDate = DateTime.Parse("2006-03-21"),
                            Genre = "Reality Television",
                            NumberOfSeasons = 14,
                            Rating = 4.1
                        },

                        new Show
                        {
                            Id = 16,
                            Title = "Below Deck",                           // Bravo --> Sling Blue, Direct Tv Plus, Hulu Live Tv, Youtube Tv
                            ReleaseDate = DateTime.Parse("2013-07-01"),
                            Genre = "Reality Television",
                            NumberOfSeasons = 7,
                            Rating = 7
                        },

                        new Show
                        {
                            Id = 17,
                            Title = "Final Space",                          // TBS --> Sling Blue, Direct Tv Plus
                            ReleaseDate = DateTime.Parse("2018-02-15"),
                            Genre = "Adventure Fiction",
                            NumberOfSeasons = 2,
                            Rating = 8.4
                        },

                        new Show
                        {
                            Id = 18,
                            Title = "Full Frontal with Samantha Bee",       // TBS --> Sling Blue, Direct Tv Plus
                            ReleaseDate = DateTime.Parse("2016-02-08"),
                            Genre = "Talk Show",
                            NumberOfSeasons = 4,
                            Rating = 5.9
                        },

                        new Show
                        {
                            Id = 19,
                            Title = "Diner, Drive-ins and Dives",           // Food Network --> Sling Blue
                            ReleaseDate = DateTime.Parse("2007-04-23"),
                            Genre = "Food",
                            NumberOfSeasons = 30,
                            Rating = 7.3
                        },

                        new Show
                        {
                            Id = 20,
                            Title = "The Pioneer Woman",                       // Food Network --> Sling Blue
                            ReleaseDate = DateTime.Parse("2011-08-27"),
                            Genre = "Home Improvement",
                            NumberOfSeasons = 23,
                            Rating = 6.1
                        },

                        new Show
                        {
                            Id = 21,
                            Title = "Warrior",                       // Cinemax --> Direct TV Max
                            ReleaseDate = DateTime.Parse("2019-04-05"),
                            Genre = "Action",
                            NumberOfSeasons = 1,
                            Rating = 8.2
                        },

                        new Show
                        {
                            Id = 22,
                            Title = "Jett",                       // Cinemax --> Direct TV Max
                            ReleaseDate = DateTime.Parse("2019-06-14"),
                            Genre = "Action Fiction",
                            NumberOfSeasons = 1,
                            Rating = 7.4
                        },

                        new Show
                        {
                            Id = 23,
                            Title = "The Big Break",                       // Golf Channel --> Direct TV Max
                            ReleaseDate = DateTime.Parse("2010-03-02"),
                            Genre = "Game Show",
                            NumberOfSeasons = 1,
                            Rating = 7.3
                        },

                        new Show
                        {
                            Id = 24,
                            Title = "Dog and Beth: On the Hunt",                       // CMT Channel --> Direct TV Max
                            ReleaseDate = DateTime.Parse("2013-03-21"),
                            Genre = "Reality Television",
                            NumberOfSeasons = 3,
                            Rating = 5.4
                        },

                        new Show
                        {
                            Id = 25,
                            Title = "Music City",                       // CMT Channel --> Direct TV Max
                            ReleaseDate = DateTime.Parse("2018-03-01"),
                            Genre = "Reality Television",
                            NumberOfSeasons = 2,
                            Rating = 5.1
                        },

                        new Show
                        {
                            Id = 26,
                            Title = "The Dude Perfect Show",                       // CMT Channel --> Direct TV Max
                            ReleaseDate = DateTime.Parse("2016-04-14"),
                            Genre = "Reality Television",
                            NumberOfSeasons = 3,
                            Rating = 6.6
                        },

                        new Show
                        {
                            Id = 27,
                            Title = "Younger",                       // TV Land Channel --> Direct TV Max
                            ReleaseDate = DateTime.Parse("2015-03-31"),
                            Genre = "Sitcom",
                            NumberOfSeasons = 6,
                            Rating = 7.8
                        },

                        new Show
                        {
                            Id = 28,
                            Title = "Impastor",                       // TV Land Channel --> Direct TV Max
                            ReleaseDate = DateTime.Parse("2015-07-15"),
                            Genre = "Sitcom",
                            NumberOfSeasons = 2,
                            Rating = 7.6
                        },

                        new Show
                        {
                            Id = 29,
                            Title = "The Soul Man",                       // TV Land Channel --> Direct TV Max
                            ReleaseDate = DateTime.Parse("2012-06-20"),
                            Genre = "Sitcom",
                            NumberOfSeasons = 5,
                            Rating = 5.7
                        },

                        new Show
                        {
                            Id = 30,
                            Title = "Lopez",                       // TV Land Channel --> Direct TV Max
                            ReleaseDate = DateTime.Parse("2016-03-03"),
                            Genre = "Sitcom",
                            NumberOfSeasons = 2,
                            Rating = 5.3
                        },

                        new Show
                        {
                            Id = 31,
                            Title = "Rehab Addict",                     // DiY Network --> Playstation Vue Core
                            ReleaseDate = DateTime.Parse("2010-10-14"),
                            Genre = "Home Improvement",
                            NumberOfSeasons = 8,
                            Rating = 7.9
                        },

                        new Show
                        {
                            Id = 32,
                            Title = "Barnwood Builders",                     // DiY Network --> Playstation Vue Core
                            ReleaseDate = DateTime.Parse("2013-11-01"),
                            Genre = "Television Documentary",
                            NumberOfSeasons = 9,
                            Rating = 7.3
                        },

                        new Show
                        {
                            Id = 33,
                            Title = "Brockmire",                     // IFC  --> Playstation Vue Core
                            ReleaseDate = DateTime.Parse("2017-04-05"),
                            Genre = "Sitcom",
                            NumberOfSeasons = 3,
                            Rating = 8.1
                        },

                        new Show
                        {
                            Id = 34,
                            Title = "Documentary Now!",                     // IFC  --> Playstation Vue Core
                            ReleaseDate = DateTime.Parse("2015-08-20"),
                            Genre = "Comedy",
                            NumberOfSeasons = 3,
                            Rating = 8.1
                        },

                        new Show
                        {
                            Id = 35,
                            Title = "Blue Bloods",                            // Law & Crime --> Playstation Vue Core
                            ReleaseDate = DateTime.Parse("2010-09-24"),
                            Genre = "Drama",
                            NumberOfSeasons = 10,
                            Rating = 7.5
                        },

                        new Show
                        {
                            Id = 36,
                            Title = "The Incredible Dr. Pol",                            // Nat Geo Wild --> Playstation Vue Core
                            ReleaseDate = DateTime.Parse("2011-10-29"),
                            Genre = "Reality Television",
                            NumberOfSeasons = 15,
                            Rating = 8.7
                        },

                        new Show
                        {
                            Id = 37,
                            Title = "Dog Whisperer With Cesar Millan",                            // Nat Geo Wild --> Playstation Vue Core
                            ReleaseDate = DateTime.Parse("2004-09-13"),
                            Genre = "Reality Television",
                            NumberOfSeasons = 9,
                            Rating = 8.7
                        },

                        new Show
                        {
                            Id = 38,
                            Title = "Carson On TCM",                            // TCM --> Playstation Vue Core
                            ReleaseDate = DateTime.Parse("2013-07-01"),
                            Genre = "Talk Show",
                            NumberOfSeasons = 2,
                            Rating = 8.9
                        },

                        new Show
                        {
                            Id = 39,
                            Title = "The Story of Film: An Odyssey",                            // TCM --> Playstation Vue Core
                            ReleaseDate = DateTime.Parse("2011-09-03"),
                            Genre = "Documentary",
                            NumberOfSeasons = 1,
                            Rating = 8.5
                        }
                        );
                }


                if (!context.ShowService.Any())
                {
                    context.ShowService.AddRange(

                        // SportsCenter --> Sling Orange, Playstation Vue Access, Hulu Live Tv, Youtube Tv
                        new ShowService
                        {
                            ServiceFK = 1,     
                            ShowFK = 1          
                        },

                        new ShowService
                        {
                            ServiceFK = 6,     
                            ShowFK = 1
                        },

                        new ShowService
                        {
                            ServiceFK = 8,      
                            ShowFK = 1
                        },

                        new ShowService
                        {
                            ServiceFK = 9,      
                            ShowFK = 1
                        },

                        // Monday Night Football --> Sling Orange, Playstation Vue Access, Hulu Live Tv, Youtube Tv
                        new ShowService
                        {
                            ServiceFK = 1,      
                            ShowFK = 2          
                        },

                        new ShowService
                        {
                            ServiceFK = 6,      
                            ShowFK = 2
                        },

                        new ShowService
                        {
                            ServiceFK = 8,     
                            ShowFK = 2
                        },

                        new ShowService
                        {
                            ServiceFK = 9,      
                            ShowFK = 2
                        },

                        // Hannah Montana --> Sling Orange, Playstation Vue Access, Hulu Live Tv, Youtube Tv
                        new ShowService
                        {
                            ServiceFK = 1,
                            ShowFK = 3
                        },

                        new ShowService
                        {
                            ServiceFK = 6,
                            ShowFK = 3
                        },

                        new ShowService
                        {
                            ServiceFK = 8,
                            ShowFK = 3
                        },

                        new ShowService
                        {
                            ServiceFK = 9,
                            ShowFK = 3
                        },

                        // Kim Possible --> Sling Orange, Playstation Vue Access, Hulu Live Tv, Youtube Tv
                        new ShowService
                        {
                            ServiceFK = 1,
                            ShowFK = 4
                        },

                        new ShowService
                        {
                            ServiceFK = 6,
                            ShowFK = 4
                        },

                        new ShowService
                        {
                            ServiceFK = 8,
                            ShowFK = 4
                        },

                        new ShowService
                        {
                            ServiceFK = 9,
                            ShowFK = 4
                        },

                        // Live PD --> Sling Orange, Hulu Live Tv

                        new ShowService
                        {
                            ServiceFK = 1,
                            ShowFK = 5
                        },

                        new ShowService
                        {
                            ServiceFK = 8,
                            ShowFK = 5
                        },

                        // Intervention --> Sling Orange, Hulu Live Tv
                        new ShowService
                        {
                            ServiceFK = 1,
                            ShowFK = 6
                        },

                        new ShowService
                        {
                            ServiceFK = 8,
                            ShowFK = 6
                        },

                        // Animal Kingdom --> Sling Orange, Direct Tv Plus, Playstation Vue Access
                        new ShowService
                        {
                            ServiceFK = 1,
                            ShowFK = 7
                        },

                        new ShowService
                        {
                            ServiceFK = 4,
                            ShowFK = 7
                        },

                        new ShowService
                        {
                            ServiceFK = 6,
                            ShowFK = 7
                        },

                        // Cold Justice --> Sling Orange, Direct Tv Plus, Playstation Vue Access
                        new ShowService
                        {
                            ServiceFK = 1,
                            ShowFK = 8
                        },

                        new ShowService
                        {
                            ServiceFK = 4,
                            ShowFK = 8
                        },

                        new ShowService
                        {
                            ServiceFK = 6,
                            ShowFK = 8
                        },

                        // The Walking Dead --> Sling Orange, Playstation Vue Access, Youtube Tv
                        new ShowService
                        {
                            ServiceFK = 1,
                            ShowFK = 9
                        },

                        new ShowService
                        {
                            ServiceFK = 6,
                            ShowFK = 9
                        },

                        new ShowService
                        {
                            ServiceFK = 9,
                            ShowFK = 9
                        },

                        // The Terror --> Sling Orange, Playstation Vue Access, Youtube Tv
                        new ShowService
                        {
                            ServiceFK = 1,
                            ShowFK = 10
                        },

                        new ShowService
                        {
                            ServiceFK = 6,
                            ShowFK = 10
                        },

                        new ShowService
                        {
                            ServiceFK = 9,
                            ShowFK = 10
                        },

                        // Suits --> Sling Blue, Direct Tv Plus, Playstation Vue Core
                        new ShowService
                        {
                            ServiceFK = 2,
                            ShowFK = 11
                        },

                        new ShowService
                        {
                            ServiceFK = 4,
                            ShowFK = 11
                        },

                        new ShowService
                        {
                            ServiceFK = 7,
                            ShowFK = 11
                        },

                        // Mr. Robot --> Sling Blue, Direct Tv Plus
                        new ShowService
                        {
                            ServiceFK = 2,
                            ShowFK = 12
                        },

                        new ShowService
                        {
                            ServiceFK = 4,
                            ShowFK = 12
                        },

                        // CNN Newsroom --> Sling Blue, Direct Tv Plus, Playstation Vue Access, Hulu Live Tv, Youtube Tv
                        new ShowService
                        {
                            ServiceFK = 2,
                            ShowFK = 13
                        },

                        new ShowService
                        {
                            ServiceFK = 4,
                            ShowFK = 13
                        },

                        new ShowService
                        {
                            ServiceFK = 6,
                            ShowFK = 13
                        },

                        new ShowService
                        {
                            ServiceFK = 8,
                            ShowFK = 13
                        },

                        new ShowService
                        {
                            ServiceFK = 9,
                            ShowFK = 13
                        },

                        // Anderson Cooper 360 --> Sling Blue, Direct Tv Plus, Playstation Vue Access, Hulu Live Tv, Youtue Tv
                        new ShowService
                        {
                            ServiceFK = 2,
                            ShowFK = 14
                        },

                        new ShowService
                        {
                            ServiceFK = 4,
                            ShowFK = 14
                        },

                        new ShowService
                        {
                            ServiceFK = 6,
                            ShowFK = 14
                        },

                        new ShowService
                        {
                            ServiceFK = 8,
                            ShowFK = 14
                        },

                        new ShowService
                        {
                            ServiceFK = 9,
                            ShowFK = 14
                        },

                        //The Real Housewives of Orange County --> Sling Blue, Direct Tv Plus, Hulu Live Tv, Youtube Tv
                        new ShowService
                        {
                            ServiceFK = 2,
                            ShowFK = 15
                        },

                        new ShowService
                        {
                            ServiceFK = 4,
                            ShowFK = 15
                        },

                        new ShowService
                        {
                            ServiceFK = 8,
                            ShowFK = 15
                        },

                        new ShowService
                        {
                            ServiceFK = 9,
                            ShowFK = 15
                        },

                        // Below Deck --> Sling Blue, Direct Tv Plus, Hulu Live Tv, Youtube Tv
                        new ShowService
                        {
                            ServiceFK = 2,
                            ShowFK = 16
                        },

                        new ShowService
                        {
                            ServiceFK = 4,
                            ShowFK = 16
                        },

                        new ShowService
                        {
                            ServiceFK = 8,
                            ShowFK = 16
                        },

                        new ShowService
                        {
                            ServiceFK = 9,
                            ShowFK = 16
                        },

                        // Final Space --> Sling Blue, Direct Tv Plus
                        new ShowService
                        {
                            ServiceFK = 2,
                            ShowFK = 17
                        },

                        new ShowService
                        {
                            ServiceFK = 4,
                            ShowFK = 17
                        },

                        // Full Frontal with Samantha Bee --> Sling Blue, Direct Tv Plus
                        new ShowService
                        {
                            ServiceFK = 2,
                            ShowFK = 18
                        },

                        new ShowService
                        {
                            ServiceFK = 4,
                            ShowFK = 18
                        },

                        // Diner, Drive-ins and Dives --> Sling Blue
                        new ShowService
                        {
                            ServiceFK = 2,
                            ShowFK = 19
                        },

                        // The Pioneer Woman --> Sling Blue
                        new ShowService
                        {
                            ServiceFK = 2,
                            ShowFK = 20
                        },

                        // Warrior --> Direct TV Max
                        new ShowService
                        {
                            ServiceFK = 5,
                            ShowFK = 21
                        },

                        // Jett --> Direct TV Max
                        new ShowService
                        {
                            ServiceFK = 5,
                            ShowFK = 22
                        },

                        // The Big Break --> Direct TV Max
                        new ShowService
                        {
                            ServiceFK = 5,
                            ShowFK = 23
                        },

                        // Dog and Beth: On the Hunt --> Direct TV Max
                        new ShowService
                        {
                            ServiceFK = 5,
                            ShowFK = 24
                        },

                        // Music City --> Direct TV Max
                        new ShowService
                        {
                            ServiceFK = 5,
                            ShowFK = 25
                        },

                        // The Dude Perfect Show --> Direct TV Max
                        new ShowService
                        {
                            ServiceFK = 5,
                            ShowFK = 26
                        },

                        // Younger --> Direct TV Max
                        new ShowService
                        {
                            ServiceFK = 5,
                            ShowFK = 27
                        },

                        // Impastor --> Direct TV Max
                        new ShowService
                        {
                            ServiceFK = 5,
                            ShowFK = 28
                        },

                        // The Soul Man --> Direct TV Max
                        new ShowService
                        {
                            ServiceFK = 5,
                            ShowFK = 29
                        },

                        // Lopez --> Direct TV Max
                        new ShowService
                        {
                            ServiceFK = 5,
                            ShowFK = 30
                        },

                        // Rehab Addict --> Playstation Vue Core
                        new ShowService
                        {
                            ServiceFK = 7,
                            ShowFK = 31
                        },

                        // Barnwood Builders --> Playstation Vue Core
                        new ShowService
                        {
                            ServiceFK = 7,
                            ShowFK = 32
                        },

                        // Brockmire  --> Playstation Vue Core
                        new ShowService
                        {
                            ServiceFK = 7,
                            ShowFK = 33
                        },

                        // Documentary Now!  --> Playstation Vue Core
                        new ShowService
                        {
                            ServiceFK = 7,
                            ShowFK = 34
                        },

                        // Blue Bloods --> Playstation Vue Core
                        new ShowService
                        {
                            ServiceFK = 7,
                            ShowFK = 35
                        },

                        // The Incredible Dr. Pol --> Playstation Vue Core
                        new ShowService
                        {
                            ServiceFK = 7,
                            ShowFK = 36
                        },

                        // Dog Whisperer With Cesar Millan --> Playstation Vue Core
                        new ShowService
                        {
                            ServiceFK = 7,
                            ShowFK = 37
                        },

                        // Carson On TCM --> Playstation Vue Core
                        new ShowService
                        {
                            ServiceFK = 7,
                            ShowFK = 38
                        },

                        // The Story of Film: An Odyssey --> Playstation Vue Core
                        new ShowService
                        {
                            ServiceFK = 7,
                            ShowFK = 39
                        }
                // Seed Show table if it is empty
                //if (!context.Show.Any())
                //{
                //    context.Show.AddRange(
                //        new Show
                //        {
                //            Title = "Game of Thrones",
                //            ReleaseDate = DateTime.Parse("2011-4-17"),
                //            Genre = "Action",
                //            NumberOfSeasons = 8,
                //            Rating = 9.4
                //        },

                //        new Show
                //        {
                //            Title = "The Simpsons",
                //            ReleaseDate = DateTime.Parse("1989-12-17"),
                //            Genre = "Comedy",
                //            NumberOfSeasons = 32,
                //            Rating = 8.7
                //        },

                //        new Show
                //        {
                //            Title = "The Office",
                //            ReleaseDate = DateTime.Parse("2005-3-24"),
                //            Genre = "Comedy",
                //            NumberOfSeasons = 9,
                //            Rating = 8.8
                //        },

                //        new Show
                //        {
                //            Title = "The Walking Dead",
                //            ReleaseDate = DateTime.Parse("2010-10-31"),
                //            Genre = "Thriller",
                //            NumberOfSeasons = 10,
                //            Rating = 8.3
                //        },

                //        new Show
                //        {
                //            Title = "Euphoria",
                //            ReleaseDate = DateTime.Parse("2019-6-16"),
                //            Genre = "Drama",
                //            NumberOfSeasons = 1,
                //            Rating = 8.4
                //        }
                //    );
                //}
                //// Seed User table if it is empty
                //if(!context.User.Any())
                //{
                //    context.User.AddRange(
                //        new User
                //        {
                //            UserName = "nRoberts2020",
                //            UserPassword = "123456789",
                //            FirstName = "Nathan",
                //            LastName = "Roberts",
                //            EmailAddress = "NR@mytvadmin.com",
                //            AccCreationDate = DateTime.Parse("2016-4-11")
                //        },

                //        new User
                //        {
                //            UserName = "bobBobbington",
                //            UserPassword = "234567891",
                //            FirstName = "Bob",
                //            LastName = "Smith",
                //            EmailAddress = "bobsmith@tacos.com",
                //            AccCreationDate = DateTime.Parse("2019-1-8")
                //        },

                //        new User
                //        {
                //            UserName = "batman4ever1955",
                //            UserPassword = "345678912",
                //            FirstName = "Bat",
                //            LastName = "Man",
                //            EmailAddress = "batman@batcave.com",
                //            AccCreationDate = DateTime.Parse("2018-4-24")
                //        }
                //    );
                //}

                        );
                }
                context.SaveChanges();
            }
        }
    }
}