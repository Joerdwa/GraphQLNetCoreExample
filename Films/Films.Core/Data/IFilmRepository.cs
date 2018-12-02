using System.Threading.Tasks;
using Films.Core.Models;

namespace Films.Core.Data
{
    public interface IFilmRepository
    {
        Task<Film> Get(int id);
    }
}
