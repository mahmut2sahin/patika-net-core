using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_api.Operations.BookOperations.GetBookById
{
    public class GetBookByIdValidator : AbstractValidator<GetBookByIdService>
    {
        public GetBookByIdValidator()
        {
            RuleFor(i => i.BookId).GreaterThan(0);
        }
    }
}
