using FluentValidation;

namespace bookstore_api.Operations.GenreOperations.Commands.AddGenre
{
    public class AddGenreValidator : AbstractValidator<AddGenreService>
    {
        public AddGenreValidator()
        {
            RuleFor(i => i.NewGenreModel.Name).NotNull().MinimumLength(4);
        }
    }
}