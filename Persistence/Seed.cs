using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Posts.Any()) return;

            List<Post> posts = new List<Post>
            {
                new Post
                {
                    Title = "Weird Dude",
                    Description = "There is a weird dude that hangs out by the shoe store and he sucks.",
                    Category = "Lookouts",
                    DateCreated = DateTime.Now,
                    DateUpdated = null
                },
                new Post
                {
                    Title = "Pizza Friday",
                    Description = "This upcoming Friday the 22nd of October there will be free pizza and drinks at the community room.",
                    Category = "Announcements",
                    DateCreated = DateTime.Now,
                    DateUpdated = null
                },
                new Post
                {
                    Title = "No Poop Bags",
                    Description = "No poop bags for dogs anywhere, now there is shit overflowing in the streets!",
                    Category = "General",
                    DateCreated = DateTime.Now,
                    DateUpdated = null
                }
            };

            await context.Posts.AddRangeAsync(posts);
            await context.SaveChangesAsync();
        }
    }
}