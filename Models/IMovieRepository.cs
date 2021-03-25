using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe.Models
{
    public interface IMovieRepository
    {
        IQueryable<EnterMovieModel> Movies { get; }
    }
}
