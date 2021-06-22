using FluentValidation;

namespace bookstore_api.Operations.BookOperations.UpdateBook
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookService>
    {
        public UpdateBookValidator()
        {
            RuleFor(i => i.Model.Title).NotNull().MinimumLength(4);
            RuleFor(i => i.Model.GenreId).GreaterThan(0).NotNull();
        }
    }
}