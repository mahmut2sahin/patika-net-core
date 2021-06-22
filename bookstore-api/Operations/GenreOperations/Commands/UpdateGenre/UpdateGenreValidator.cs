using FluentValidation;

namespace bookstore_api.Operations.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreService>
    {
        public UpdateGenreValidator()
        {
            RuleFor(i => i.Id).GreaterThan(0);
            RuleFor(i => i.Model.Name).NotNull().MinimumLength(4);
        }
    }
}