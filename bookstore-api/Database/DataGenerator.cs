using bookstore_api.Common;
using bookstore_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace bookstore_api.Database
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
            new Book
            { /*Id = 1,*/
                Title = "Lean Startup",
                GenreId = (int)GenreEnum.PersonalGrowth,
                PageCount = 200,
                PublishDate = new DateTime(2001, 06, 12)
            },
            new Book
            { /*Id = 2,*/
                Title = "Herland",
                GenreId = (int)GenreEnum.Noval,
                PageCount = 250,
                PublishDate = new DateTime(2001, 05, 23)
            },
            new Book
            { /*Id = 3,*/
                Title = "Dune",
                GenreId = (int)GenreEnum.ScienceFiction,
                PageCount = 540,
                PublishDate = new DateTime(2001, 12, 21)
            });
                context.SaveChanges();
            }
        }
    }
}