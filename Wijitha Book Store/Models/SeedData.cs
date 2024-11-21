using Microsoft.EntityFrameworkCore;
using Wijitha_Book_Store.Data;

namespace Wijitha_Book_Store.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Wijitha_Book_StoreContext(
                serviceProvider.GetRequiredService<DbContextOptions<Wijitha_Book_StoreContext>>()))
            {
                // Check if the database contains any books
                if (context.Book.Any())
                {
                    return; // Database already seeded
                }

                // Add books to the database
                context.Book.AddRange(
                    new Book
                    {
                        Name = "Fantasy Adventure",
                        Title = "Bröderna Lejonhjärta",
                        Description = "A classic Swedish fantasy tale.",
                        Author = "Astrid Lindgren",
                        ISBN = "9789129688313",
                        DatePublished = DateTime.Parse("2013-9-26"),
                        Price = 139,
                        ImageUrl = "/images/lejonhjärta.jpg"
                    },
                    new Book
                    {
                        Name = "Epic Fantasy",
                        Title = "The Fellowship of the Ring",
                        Description = "The first book of The Lord of the Rings trilogy.",
                        Author = "J. R. R. Tolkien",
                        ISBN = "9780261102354",
                        DatePublished = DateTime.Parse("1991-7-4"),
                        Price = 100,
                        ImageUrl = "/images/lotr.jpg"
                    },
                    new Book
                    {
                        Name = "Crime Thriller",
                        Title = "Mystic River",
                        Description = "A gripping crime drama.",
                        Author = "Dennis Lehane",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("2011-6-1"),
                        Price = 91,
                        ImageUrl = "/images/mystic-river.jpg"
                    },
                    new Book
                    {
                        Name = "Classic Fiction",
                        Title = "Of Mice and Men",
                        Description = "A tale of friendship and hardship.",
                        Author = "John Steinbeck",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("1994-1-2"),
                        Price = 166,
                        ImageUrl = "/images/of-mice-and-men.jpg"
                    },
                    new Book
                    {
                        Name = "Literary Classic",
                        Title = "The Old Man and the Sea",
                        Description = "An iconic story of struggle and resilience.",
                        Author = "Ernest Hemingway",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("1994-8-18"),
                        Price = 84,
                        ImageUrl = "/images/old-man-and-the-sea.jpg"
                    },
                    new Book
                    {
                        Name = "Post-Apocalyptic Fiction",
                        Title = "The Road",
                        Description = "A story of survival in a dystopian world.",
                        Author = "Cormac McCarthy",
                        ISBN = "9780307386458",
                        DatePublished = DateTime.Parse("2007-5-1"),
                        Price = 95,
                        ImageUrl = "/images/the-road.jpg"
                    }
                );

                // Save changes to the database
                context.SaveChanges();
            }
        }


    }
}
