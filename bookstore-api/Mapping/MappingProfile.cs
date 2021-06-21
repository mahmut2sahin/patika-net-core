using AutoMapper;
using bookstore_api.Common;
using bookstore_api.Models;
using bookstore_api.Operations.BookOperations.GetBookById;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static bookstore_api.Operations.BookOperations.AddBook.AddBookService;
using static bookstore_api.Operations.BookOperations.GetBookById.GetBookByIdService;
using static bookstore_api.Operations.BookOperations.GetBooks.GetBooksService;
using static bookstore_api.Operations.BookOperations.UpdateBook.UpdateBookService;

namespace bookstore_api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BookByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<AddBookModel, Book>();
            CreateMap<UpdateBookModel, Book>();
        }
    }
}
