using FluentValidation;

namespace bookstore_api.Operations.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdValidator : AbstractValidator<GetGenreByIdService>
    {
        public GetGenreByIdValidator()
        {
            RuleFor(i => i.genreId).GreaterThan(0).NotNull();
        }
    }
}