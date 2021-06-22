using FluentValidation;

namespace bookstore_api.Operations.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenreService>
    {
        public DeleteGenreValidator()
        {
            RuleFor(i => i.Id).GreaterThan(0);
        }
    }
}