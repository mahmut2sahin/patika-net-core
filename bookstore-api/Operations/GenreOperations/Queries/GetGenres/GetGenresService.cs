using AutoMapper;
using bookstore_api.Database;
using System.Collections.Generic;
using System.Linq;

namespace bookstore_api.Operations.GenreOperations.Queries.GetGenres
{
    public class GetGenresService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GetGenresService(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genresList = context.Genres.Where(i => i.IsActive == true).ToList();
            var result = mapper.Map<List<GenresViewModel>>(genresList);
            return result;
        }
    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}