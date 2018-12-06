using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Films.Api.Models;
using System.Threading.Tasks;
namespace Films.Api.Controllers
{
    [Route("api")]
    public class GraphQlController : Controller
    {
        private readonly MovieQuery _filmQuery;

        public GraphQlController(MovieQuery filmQuery){
            _filmQuery = filmQuery;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = _filmQuery };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
