using AutoMapper;
using bookstore_api.Database;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_api.Operations.BookOperations.GetBookById
{
    public class GetBookByIdService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public int BookId { get; }

        public GetBookByIdService(BookStoreDbContext context, IMapper mapper, int id)
        {
            this.context = context;
            this.mapper = mapper;
            this.BookId = id;
        }
        

        public BookByIdViewModel Handle()
        {
            var book = context.Books.FirstOrDefault(i => i.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı!");
            }
            var vm = mapper.Map<BookByIdViewModel>(book);
            return vm;
        }

        public class BookByIdViewModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }

        }
    }
}
