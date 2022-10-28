using Dapper;
using DataBase.Models;
using DataBase.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Linq;

namespace DataBase.Repository
{
    public class MovieRepository : IMovieRepository
    {

        private readonly ILogger<MovieRepository> _logger;
        private readonly IConfiguration _config;
        private readonly string _connection;

        public MovieRepository(ILogger<MovieRepository> logger, IConfiguration config )
        {
            _logger = logger;
            _config = config;
            _connection = _config.GetConnectionString("DefaultConnection");
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            Movie resultMovie = null;

            try
            {
                using (var connection = new SqlConnection(_connection))
                {
                    var stringBuilder = new System.Text.StringBuilder();
                    stringBuilder.AppendLine(@"INSERT INTO TB_MOVIES");
                    stringBuilder.AppendLine(@" (TITLE,");
                    stringBuilder.AppendLine(@" DS_MOVIE,");
                    stringBuilder.AppendLine(@" URL)");
                    stringBuilder.AppendLine(@" VALUES(");
                    stringBuilder.AppendLine($"'{movie.TITLE}',");
                    stringBuilder.AppendLine($"'{movie.DS_MOVIE}',");
                    stringBuilder.AppendLine($"'{movie.URL}')");

                    var insertMovie = await connection.QueryAsync<Movie>(stringBuilder.ToString());

                    resultMovie = connection.Query<Movie>("SELECT TOP(1) * FROM TB_MOVIES ORDER BY ID_MOVIE DESC").FirstOrDefault();

                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Error: " + ex.Message);
            }

            return resultMovie;
        }

        public async Task<List<Movie>> ListMovies()
        {
            List<Movie> movies = new List<Movie>();
            try
            {
                using (var connection = new SqlConnection(_connection))
                {
                    var stringBuilder = new System.Text.StringBuilder();
                    stringBuilder.AppendLine(@"SELECT");
                    stringBuilder.AppendLine(@" *");
                    stringBuilder.AppendLine(@" FROM");
                    stringBuilder.AppendLine(@" TB_MOVIES");

                    movies = (await connection.QueryAsync<Movie>(stringBuilder.ToString())).AsList();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
            }

            return movies;
        }

        public async Task<Movie> GetMovieByID(int id)
        {
            Movie movie = new Movie();
            try
            {
                using (var connection = new SqlConnection(_connection))
                {
                    var stringBuilder = new System.Text.StringBuilder();
                    stringBuilder.AppendLine(@"SELECT");
                    stringBuilder.AppendLine(@" *");
                    stringBuilder.AppendLine(@" FROM");
                    stringBuilder.AppendLine(@" TB_MOVIES");
                    stringBuilder.AppendLine($" WHERE ID_MOVIE = {id}");

                    movie = (await connection.QueryAsync<Movie>(stringBuilder.ToString())).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
            }

            return movie;
        }
    }
}