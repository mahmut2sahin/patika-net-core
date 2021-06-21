using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static bookstore_api.Operations.BookOperations.AddBook.AddBookService;

namespace bookstore_api.Operations.BookOperations.AddBook
{
    public class AddBookValidator : AbstractValidator<AddBookModel>
    {
        public AddBookValidator()
        {
            RuleFor(i => i.Title).NotNull().MinimumLength(4);
            RuleFor(i => i.GenreId).InclusiveBetween(1, 3).NotNull();
        }
    }
}
