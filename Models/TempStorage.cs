using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DateMe.Models
{

    public static class TempStorage
    {
        private static List<EnterMovieModel> movies = new List<EnterMovieModel>();
        public static IEnumerable<EnterMovieModel> Movies => movies;
        public static void AddMovie(EnterMovieModel movie)
        {
            movies.Add(movie);
        }
    }
}