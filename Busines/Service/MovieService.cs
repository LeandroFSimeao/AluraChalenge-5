using AutoMapper;
using Busines.DTO;
using Busines.Helpers;
using Busines.Service.Interfaces;
using DataBase.Models;
using DataBase.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Busines.Service
{
    public class MovieService : IMovieService
    {
        private readonly ILogger<MovieService> _logger;
        public readonly IMovieRepository _movieRepository;
        IMapper _mapper;

        public MovieService(ILogger<MovieService> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
            var cfg = new MapperConfigurationExpression();
            cfg.AddProfile<MappingProfiles>();
            var mapperConfig = new MapperConfiguration(cfg);
            _mapper = new Mapper(mapperConfig);
        }

        public async Task<List<MovieDTO>> GetMovies()
        {
            return _mapper.Map<List<MovieDTO>>( await _movieRepository.ListMovies());
        }

        public async Task<MovieDTO> GetMovieById(int id)
        {
            return _mapper.Map<MovieDTO>(await _movieRepository.GetMovieByID(id));
        }

        public async Task<MovieDTO> Create(MovieDTO dto)
        {
            return _mapper.Map<MovieDTO>(await _movieRepository.CreateMovie(_mapper.Map<Movie>(dto)));
        }

    }
}