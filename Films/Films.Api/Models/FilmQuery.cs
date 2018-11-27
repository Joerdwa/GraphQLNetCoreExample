using GraphQL.Types;
using Films.Core.Models;

namespace Films.Api.Models
{
    public class FilmQuery : ObjectGraphType
    {
        public FilmQuery()
        {
            Field<FilmType>(
              "film",
              resolve: context => new Film { Id = 1, Name = "Donnie Darko" }
            );
        }
    }
}
