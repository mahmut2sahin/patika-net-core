using AutoMapper;
using bookstore_api.Database;
using bookstore_api.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace bookstore_api.Operations.BookOperations.AddBook
{
    public class AddBookService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public AddBookService(BookStoreDbContext context, IMapper mapper, AddBookModel newBook)
        {
            this.context = context;
            this.mapper = mapper;
            this.NewBook = newBook;
        }

        public AddBookModel NewBook { get; }
        public int Handle()
        {
            var book = context.Books.FirstOrDefault(i => i.Title == NewBook.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }
            Book toBeAdded = mapper.Map<Book>(NewBook);
            context.Add(toBeAdded);
            context.SaveChanges();
            return toBeAdded.Id;
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
