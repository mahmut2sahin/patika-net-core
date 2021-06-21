using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_api.Operations.BookOperations.DeleteBook
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookService>
    {
        public DeleteBookValidator()
        {
            RuleFor(i => i.BookId).GreaterThan(0);
        }
    }
}
