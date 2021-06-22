using AutoMapper;
using bookstore_api.Database;
using bookstore_api.Operations.GenreOperations.Commands.AddGenre;
using bookstore_api.Operations.GenreOperations.Commands.DeleteGenre;
using bookstore_api.Operations.GenreOperations.Commands.UpdateGenre;
using bookstore_api.Operations.GenreOperations.Queries.GetGenreById;
using bookstore_api.Operations.GenreOperations.Queries.GetGenres;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static bookstore_api.Operations.GenreOperations.Commands.AddGenre.AddGenreService;
using static bookstore_api.Operations.GenreOperations.Commands.UpdateGenre.UpdateGenreService;

namespace bookstore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GenresController(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresService service = new(context, mapper);
            var result = service.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            GetGenreByIdService service = new(context, mapper, id);
            GetGenreByIdValidator validator = new();
            validator.ValidateAndThrow(service);
            var result = service.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre(AddGenreModel NewGenreModel)
        {
            AddGenreService service = new(context, mapper, NewGenreModel);
            AddGenreValidator validator = new();
            validator.ValidateAndThrow(service);
            var resultId = service.Handle();
            return CreatedAtAction(nameof(GetGenreById), routeValues: new { id = resultId }, value: null);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, UpdateGenreModel model)
        {
            UpdateGenreService service = new(context, mapper, model, id);
            UpdateGenreValidator validator = new();
            validator.ValidateAndThrow(service);
            service.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreService service = new(context, mapper, id);
            DeleteGenreValidator validator = new();
            validator.ValidateAndThrow(service);
            service.Handle();
            return Ok();
        }
    }
}