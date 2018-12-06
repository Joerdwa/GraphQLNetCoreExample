using System.Linq;
using Films.Core.Models;

namespace Films.Data.EntityFramework.Seed
{
    public static class MoviesSeedData
    {
        public static void EnsureSeedData(this MovieContext db)
        {
            if (!db.Films.Any())
            {
                var film = new Film
                {
                    Name = "Donnie Darko"
                };
                db.Films.Add(film);
                db.SaveChanges();
            }
        }
    }
}
