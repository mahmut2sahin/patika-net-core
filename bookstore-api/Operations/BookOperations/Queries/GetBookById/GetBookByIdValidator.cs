using FluentValidation;

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