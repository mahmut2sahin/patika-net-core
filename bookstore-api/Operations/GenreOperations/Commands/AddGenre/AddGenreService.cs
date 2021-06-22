using AutoMapper;
using bookstore_api.Database;
using bookstore_api.Entities;
using System;
using System.Linq;

namespace bookstore_api.Operations.GenreOperations.Commands.AddGenre
{
    public class AddGenreService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public AddGenreService(BookStoreDbContext context, IMapper mapper, AddGenreModel NewGenreModel)
        {
            this.context = context;
            this.mapper = mapper;
            this.NewGenreModel = NewGenreModel;
        }

        public AddGenreModel NewGenreModel { get; }

        public int Handle()
        {
            var searchResult = context.Genres.FirstOrDefault(i => i.Name == NewGenreModel.Name);
            if (searchResult is not null)
            {
                throw new InvalidOperationException("Böyle bir kitap türü zaten mevcut");
            }
            else
            {
                var result = mapper.Map<Genre>(NewGenreModel);
                context.Genres.Add(result);
                context.SaveChanges();
                return result.Id;
            }
        }

        public class AddGenreModel
        {
            public string Name { get; set; }
        }
    }
}