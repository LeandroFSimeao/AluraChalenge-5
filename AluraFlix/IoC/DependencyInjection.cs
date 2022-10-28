using Busines.DTO;
using Busines.Service;
using Busines.Service.Interfaces;
using DataBase.Repository;
using DataBase.Repository.Interfaces;

namespace AluraFlix.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services )
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();

            return services;
        }

        public static IServiceCollection LerArquivoConfiguracao(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.Configure<ConexaoDTO>(configuration.GetSection("ConnectionStrings"));

            return services;
        }
    }
}
