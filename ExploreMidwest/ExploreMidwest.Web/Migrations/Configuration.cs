namespace ExploreMidwest.Data.Migrations
{
    using ExploreMidwest.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExploreMidwest.Data.ExploreMidwestDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExploreMidwest.Data.ExploreMidwestDBContext context)
        {
            context.Blog.AddOrUpdate(b => b.Title,
                new Blog
                {
                    Title = "Keweenaw Peninsula",
                    Body = "The only things crowding Michigan's Keweenaw Peninsula in autumn are miles of coastline, " +
                            "fall color and Lake Superior lore.",
                    Category = new Category
                    {
                        CategoryId = 1,
                        CategoryType = "Michigan"
                    },
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            TagsId = 1,
                            TagName = "#Fall"
                        },
                        new Tags
                        {
                            TagsId = 2,
                            TagName = "#BeautifulFall"
                        }
                    },
                    IsFinished = true,
                    IsDeleted = false,
                    Date = DateTime.Parse("10/26/2017"),
                },

                new Blog
                {
                    Title = "Cana Island Lighthouse ",
                    Body = "The 100-step climb to the top of Cana Island Lighthouse in Bailey's Harbor rewards visitors with " +
                           "some of the best views of Lake Michigan's Door County shoreline",
                    Category = new Category
                    {
                        CategoryId = 2,
                        CategoryType = "Wisconsin"
                    },

                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            TagsId = 1,
                            TagName = "#SummerHoliday"
                        },
                        new Tags
                        {
                            TagsId = 2,
                            TagName = "#SummerGateAway"
                        }
                    },
                    IsFinished = true,
                    IsDeleted = false,
                    Date = DateTime.Parse("7/04/2017")

                },
                new Blog
                {
                    Title = "Best Bets for Fall Fun in Stillwater",
                    Body = "Who needs Venice, Italy? Get cozy in the cushioned seats of a Venetian gondola powered by " +
                            "a gondolier wearing a striped shirt and straw hat. For optimal romance, book a dinner package " +
                            "through the Dock Cafe and time a 45-minute gondola ride to watch the moon rise over the St. Croix River",
                    Category = new Category
                    {
                        CategoryId = 3,
                        CategoryType = "Minnesota"
                    },
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            TagsId = 1,
                            TagName = "#BestGateAway"
                        },
                        new Tags
                        {
                            TagsId = 2,
                            TagName = "#WhoNeedsVenice"
                        }
                    },
                    IsFinished = true,
                    IsDeleted = false,
                    Date = DateTime.Parse("05/10/2017")
                },
                new Blog
                {
                    Title = "Get Lost in These Midwest Corn Mazes",
                    Body = "As if pulling off huge harvests and supplying food to the world wasn't enough, " +
                          "Midwest farmers also have an artsy side. Elaborate corn mazes put their design skills on full display. " +
                          "Bonus: Navigating through one is a crazy-fun way to spend an autumn afternoon",
                    Category = new Category
                    {
                        CategoryId = 4,
                        CategoryType = "Wisconsin"
                    },
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            TagsId = 1,
                            TagName = "#CornFarm"
                        }
                    },
                    IsFinished = true,
                    IsDeleted = false,
                    Date = DateTime.Parse("10/29/2017")

                },
                new Blog
                {
                    Title = "The Trick to Planning the Perfect Fall Getaway",
                    Body = "Time your autumn escape just right with these handy fall color reports " +
                           "from state tourism and natural resources groups.",
                    Category = new Category
                    {
                        CategoryId = 5,
                        CategoryType = "Minnesota"
                    },
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            TagsId = 1,
                            TagName ="#TenThousandLakes"
                        }
                    },
                    IsFinished = true,
                    IsDeleted = false,
                    Date = DateTime.Parse("03/22/2017")
                },
                new Blog
                {
                    Title = "The good life along Illinois’ Shawnee Hills Wine Trail",
                    Body = "Becky Schneider pours a taste of Golden Oak Aged Reserve in the sun-washed tasting room" +
                           " at Pomona Winery near Alto Pass, Illinois, and watches as Anne Pitts sips it. " +
                           " “I used to have a problem calling wine creamy until this one,” Becky says, " +
                           " grinning as a familiar look of wonder spreads across Anne’s face and adding, " +
                           " “I’ve never tasted anything like it. I steam a lot of veggies in it; I throw it in pasta sauces",
                    Category = new Category
                    {
                        CategoryId = 6,
                        CategoryType = "Illionis"
                    },
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            TagsId = 1,
                            TagName = "#WineTrail"

                        },
                                           
                    },
                    IsFinished = false,
                    IsDeleted = false,
                    Date = DateTime.Parse("08/02/2017")

                }
                
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
