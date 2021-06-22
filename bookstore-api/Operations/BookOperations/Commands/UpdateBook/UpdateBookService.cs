using AutoMapper;
using bookstore_api.Database;
using bookstore_api.Entities;
using System;
using System.Linq;

namespace bookstore_api.Operations.BookOperations.UpdateBook
{
    public class UpdateBookService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        private readonly int id;
        public UpdateBookModel Model { get; }

        public UpdateBookService(BookStoreDbContext context, IMapper mapper, UpdateBookModel updatedBook, int id)
        {
            this.context = context;
            this.mapper = mapper;
            this.id = id;
            this.Model = updatedBook;
        }

        public void Handle()
        {
            var book = context.Books.FirstOrDefault(i => i.Id == id);
            bool GenreCheck = context.Genres.Any(i => i.Id == Model.GenreId);
            if (book is not null && GenreCheck is true)
            {
                var updatedBook = mapper.Map<UpdateBookModel, Book>(Model, book);
                context.Entry(book).CurrentValues.SetValues(updatedBook);
                context.SaveChanges();
            }
            else
                throw new InvalidOperationException("Böyle bir kitap yok ya da girilen kitap türü sistemde kayıtlı değil!");
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }
    }
}