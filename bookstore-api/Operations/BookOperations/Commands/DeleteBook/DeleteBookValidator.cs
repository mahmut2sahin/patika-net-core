using FluentValidation;

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