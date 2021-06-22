using AutoMapper;
using bookstore_api.Entities;
using bookstore_api.Operations.GenreOperations.Queries.GetGenreById;
using bookstore_api.Operations.GenreOperations.Queries.GetGenres;
using static bookstore_api.Operations.BookOperations.AddBook.AddBookService;
using static bookstore_api.Operations.BookOperations.GetBookById.GetBookByIdService;
using static bookstore_api.Operations.BookOperations.GetBooks.GetBooksService;
using static bookstore_api.Operations.BookOperations.UpdateBook.UpdateBookService;
using static bookstore_api.Operations.GenreOperations.Commands.AddGenre.AddGenreService;
using static bookstore_api.Operations.GenreOperations.Commands.UpdateGenre.UpdateGenreService;

namespace bookstore_api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BookByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<AddBookModel, Book>();
            CreateMap<UpdateBookModel, Book>();
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreByIdViewModel>();
            CreateMap<AddGenreModel, Genre>();
            CreateMap<UpdateGenreModel, Genre>();
        }
    }
}