using Busines.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines.Service.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieDTO>> GetMovies();
        Task<MovieDTO> Create(MovieDTO dto);
        Task<MovieDTO> GetMovieById(int id);
    }
}
