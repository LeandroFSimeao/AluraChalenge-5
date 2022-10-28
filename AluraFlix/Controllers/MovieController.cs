using Busines.DTO;
using Busines.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie(MovieDTO dto)
        {
            MovieDTO movieDTO = await _movieService.Create(dto);
            return Created("Criado", movieDTO);
        }

        [HttpGet]
        public async Task<ActionResult> GetMovies()
        {
            List<MovieDTO> readDTO = await _movieService.GetMovies();
            if(readDTO != null) return Ok(readDTO);
            return NotFound();
        }

        [HttpGet("{idMovie}")]
        public async Task<ActionResult> GetMovieById(int idMovie)
        {
            MovieDTO readDTO = await _movieService.GetMovieById(idMovie);
            if (readDTO != null) return Ok(readDTO);
            return NotFound();
        }


    }
}
