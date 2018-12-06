using Films.Core.Models;
using GraphQL.Types;

namespace Films.Api.Models
{
    public class FilmType : ObjectGraphType<Film>
    {
        public FilmType(){
            Field(x => x.Id).Description("The id of the film.");
            Field(x => x.Name, nullable: true).Description("The name of the film.");
        }
    }
}
