using AutoMapper;
using bookstore_api.Database;
using System;
using System.Linq;

namespace bookstore_api.Operations.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public DeleteGenreService(BookStoreDbContext context, IMapper mapper, int id)
        {
            this.context = context;
            this.mapper = mapper;
            Id = id;
        }

        public int Id { get; }

        public void Handle()
        {
            var genre = context.Genres.FirstOrDefault(i => i.Id == Id);
            if (genre is null)
            {
                throw new InvalidOperationException("Böyle bir kitap türü yok!");
            }
            else
            {
                context.Genres.Remove(genre);
                context.SaveChanges();
            }
        }
    }
}