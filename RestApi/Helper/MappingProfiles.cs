using AutoMapper;
using RestApi.Dto;
using RestApi.Models;

namespace RestApi.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();        
        }
    }
}
