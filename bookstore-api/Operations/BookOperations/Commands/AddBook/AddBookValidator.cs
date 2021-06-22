using FluentValidation;

namespace bookstore_api.Operations.BookOperations.AddBook
{
    public class AddBookValidator : AbstractValidator<AddBookService>
    {
        public AddBookValidator()
        {
            RuleFor(i => i.NewBookModel.Title).NotNull().MinimumLength(4);
            RuleFor(i => i.NewBookModel.GenreId).GreaterThan(0).NotNull();
        }
    }
}