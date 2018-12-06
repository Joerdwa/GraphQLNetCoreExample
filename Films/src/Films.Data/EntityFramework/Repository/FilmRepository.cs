using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Films.Core.Models;
using Films.Core.Data;

namespace Films.Data.EntityFramework.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private MovieContext _db { get; set; }

        public FilmRepository(MovieContext db)
        {
            _db = db;
        }

        public Task<Film> Get(int id)
        {
            return _db.Films.FirstOrDefaultAsync(film => film.Id == id);
        }
    }
}
