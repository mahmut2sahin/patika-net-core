using AutoMapper;
using bookstore_api.Database;
using bookstore_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_api.Operations.BookOperations.UpdateBook
{
    public class UpdateBookService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        private readonly int id;

        public UpdateBookService(BookStoreDbContext context, IMapper mapper, UpdateBookModel updatedBook, int id)
        {
            this.context = context;
            this.mapper = mapper;
            this.id = id;
            this.UpdatedBook = updatedBook;
        }

        public UpdateBookModel UpdatedBook { get; }

        public void Handle()
        {
            var book = context.Books.FirstOrDefault(i => i.Id == id);
            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap yok!");
            }
            var newbook = mapper.Map<UpdateBookModel, Book>(UpdatedBook, book);
            context.Entry(book).CurrentValues.SetValues(newbook);
            context.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }
    }
}
