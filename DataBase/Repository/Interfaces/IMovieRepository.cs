using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> ListMovies();

        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> GetMovieByID(int id);
    }
}
