using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe.Models
{
    public class EFMovieRespository : IMovieRepository
    {

        private MovieDbContext _context;

        public EFMovieRespository (MovieDbContext context)
        {
            _context = context;
        }
        public IQueryable<EnterMovieModel> Movies => _context.Movies;
    }
}
