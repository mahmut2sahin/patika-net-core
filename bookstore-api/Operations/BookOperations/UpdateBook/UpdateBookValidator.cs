using bookstore_api.Operations.BookOperations.AddBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static bookstore_api.Operations.BookOperations.UpdateBook.UpdateBookService;

namespace bookstore_api.Operations.BookOperations.UpdateBook
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookModel>
    {
        public UpdateBookValidator()
        {
            RuleFor(i => i.Title).NotNull().MinimumLength(4);
            RuleFor(i => i.GenreId).InclusiveBetween(1, 3).NotNull();
        }
    }
}
