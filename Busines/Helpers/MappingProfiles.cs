using AutoMapper;
using Busines.DTO;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
        }
    }
}
