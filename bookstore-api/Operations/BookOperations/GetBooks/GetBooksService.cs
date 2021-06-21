using AutoMapper;
using bookstore_api.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_api.Operations.BookOperations.GetBooks
{
    public class GetBooksService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GetBooksService(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public List<BooksViewModel> Handle()
        {
            var bookList = context.Books.ToList();
            List<BooksViewModel> vm = mapper.Map<List<BooksViewModel>>(bookList);
            return vm;
        }
        public class BooksViewModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
        }
    }
}
