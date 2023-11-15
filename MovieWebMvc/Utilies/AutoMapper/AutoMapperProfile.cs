using AutoMapper;
using EntityLayer;
using MovieWebMvc.Models;

namespace MovieWebMvc.Utilies.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieDto,Movies>().ReverseMap();
            CreateMap<MovieDto, MovieListVM>();
        }
    }
}
