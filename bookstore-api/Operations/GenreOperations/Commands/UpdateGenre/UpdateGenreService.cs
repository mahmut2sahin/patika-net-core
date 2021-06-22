using AutoMapper;
using bookstore_api.Database;
using bookstore_api.Entities;
using System;
using System.Linq;

namespace bookstore_api.Operations.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public UpdateGenreService(BookStoreDbContext context, IMapper mapper, UpdateGenreModel Model, int id)
        {
            this.context = context;
            this.mapper = mapper;
            this.Model = Model;
            Id = id;
        }

        public UpdateGenreModel Model { get; }
        public int Id { get; }

        public void Handle()
        {
            //var genre = context.Genres.FirstOrDefault(i => i.Id == Id && i.Name != Model.Name);
            var genre = context.Genres.FirstOrDefault(i => i.Id == this.Id);
            bool GenreCheck = context.Genres.Any(i => i.Name == Model.Name);
            if (genre is null || GenreCheck is true)
            {
                throw new InvalidOperationException("Böyle bir kitap türü yok ya da aynı isimde zaten bir kitap türü var!");
            }
            else
            {
                var updatedGenre = mapper.Map<UpdateGenreModel, Genre>(Model, genre);
                context.SaveChanges();
            }
        }

        public class UpdateGenreModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}