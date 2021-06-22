using AutoMapper;
using bookstore_api.Database;
using bookstore_api.Operations.BookOperations.AddBook;
using bookstore_api.Operations.BookOperations.DeleteBook;
using bookstore_api.Operations.BookOperations.GetBookById;
using bookstore_api.Operations.BookOperations.GetBooks;
using bookstore_api.Operations.BookOperations.UpdateBook;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static bookstore_api.Operations.BookOperations.AddBook.AddBookService;
using static bookstore_api.Operations.BookOperations.UpdateBook.UpdateBookService;

namespace bookstore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public BooksController(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksService service = new(context, mapper);
            var result = service.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            GetBookByIdService service = new(context, mapper, id);
            GetBookByIdValidator validator = new();
            validator.ValidateAndThrow(service);
            var result = service.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook(AddBookModel newBook)
        {
            AddBookValidator validator = new();
            AddBookService service = new(context, mapper, newBook);
            int bookId;
            validator.ValidateAndThrow(service);
            bookId = service.Handle();
            return CreatedAtAction(nameof(GetBookById), routeValues: new { id = bookId }, value: null);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, UpdateBookModel updateBook)
        {
            UpdateBookValidator validator = new();
            UpdateBookService service = new(context, mapper, updateBook, id);
            validator.ValidateAndThrow(service);
            service.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookService service = new(context, id);
            DeleteBookValidator validator = new();
            validator.ValidateAndThrow(service);
            service.Handle();
            return Ok();
        }
    }
}