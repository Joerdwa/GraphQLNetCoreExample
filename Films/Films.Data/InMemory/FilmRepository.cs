using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Films.Core.Data;
using Films.Core.Models;

namespace Films.Data.InMemory
{
    public class FilmRepository : IFilmRepository
    {
        private readonly List<Film> _films = new List<Film> {
            new Film  {Id = 1, Name = "Donnie Darko" }
        };

        public Task<Film> Get(int id)
        {
            return Task.FromResult(_films.FirstOrDefault(film => film.Id == id));
        }
    }
}
