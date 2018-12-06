using GraphQL.Types;
using Films.Core.Models;
using Films.Core.Data;

namespace Films.Api.Models
{
    public class MovieQuery : ObjectGraphType
    {
        private readonly IFilmRepository _filmRepository;

        public MovieQuery(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;

            Field<FilmType>(
              "film",
                resolve: context => _filmRepository.Get(1)
            );
        }
    }
}
