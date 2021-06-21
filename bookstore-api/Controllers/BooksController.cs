using AutoMapper;
using bookstore_api.Database;
using bookstore_api.Operations.BookOperations.GetBooks;
using bookstore_api.Operations.BookOperations.GetBookById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static bookstore_api.Operations.BookOperations.GetBookById.GetBookByIdService;
using bookstore_api.Operations.BookOperations.AddBook;
using static bookstore_api.Operations.BookOperations.AddBook.AddBookService;
using bookstore_api.Operations.BookOperations.UpdateBook;
using static bookstore_api.Operations.BookOperations.UpdateBook.UpdateBookService;
using System.Security.Cryptography.X509Certificates;
using bookstore_api.Operations.BookOperations.DeleteBook;
using FluentValidation;

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
            BookByIdViewModel result;
            GetBookByIdService service = new(context, mapper, id);
            GetBookByIdValidator validator = new();
            try
            {
                validator.ValidateAndThrow(service);
                result = service.Handle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBook(AddBookModel newBook)
        {
            AddBookValidator validator = new();
            AddBookService service = new(context, mapper, newBook);
            int bookId;
            try
            {
                validator.ValidateAndThrow(newBook);
                bookId = service.Handle();
                return CreatedAtAction(nameof(GetBookById), routeValues: new { id = bookId }, value: null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, UpdateBookModel updateBook)
        {
            UpdateBookValidator validator = new();
            UpdateBookService service = new(context, mapper, updateBook, id);
            try
            {
                validator.ValidateAndThrow(updateBook);
                service.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookService service = new(context, id);
            DeleteBookValidator validator = new();
            try
            {
                validator.ValidateAndThrow(service);
                service.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
