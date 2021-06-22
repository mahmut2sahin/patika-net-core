using AutoMapper;
using bookstore_api.Database;
using System;
using System.Linq;

namespace bookstore_api.Operations.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public int genreId;

        public GetGenreByIdService(BookStoreDbContext context, IMapper mapper, int genreId)
        {
            this.context = context;
            this.mapper = mapper;
            this.genreId = genreId;
        }

        public GenreByIdViewModel Handle()
        {
            var book = context.Genres.FirstOrDefault(item => item.Id == genreId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı!");
            }
            var result = mapper.Map<GenreByIdViewModel>(book);
            return result;
        }
    }

    public class GenreByIdViewModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}