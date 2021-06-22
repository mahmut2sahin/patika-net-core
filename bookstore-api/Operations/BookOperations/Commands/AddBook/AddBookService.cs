using AutoMapper;
using bookstore_api.Database;
using bookstore_api.Entities;
using System;
using System.Linq;

namespace bookstore_api.Operations.BookOperations.AddBook
{
    public class AddBookService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public AddBookModel NewBookModel;

        public AddBookService(BookStoreDbContext context, IMapper mapper, AddBookModel newBook)
        {
            this.context = context;
            this.mapper = mapper;
            this.NewBookModel = newBook;
        }

        public int Handle()
        {
            //var book = context.Books.Include(i => i.Genre).FirstOrDefault(i => i.Title == NewBookModel.Title);
            bool BookCheck = context.Books.Any(i => i.Title == NewBookModel.Title);
            bool GenreCheck = context.Genres.Any(i => i.Id == NewBookModel.GenreId);
            if (BookCheck is false && GenreCheck is true)
            {
                Book newBook = mapper.Map<Book>(NewBookModel);
                context.Add(newBook);
                context.SaveChanges();
                return newBook.Id;
            }
            else
                throw new InvalidOperationException("Kitap zaten mevcut ya da belirtilen kitap türü sistemde kayıtlı değil!");
        }

        public class AddBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}