using AutoMapper;
using PokemonReviewApp.DTO;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>(); //'CreateMap' method to configure a mapping between the 'Pokemon' class and 'PokemonDto' class
            //tells automapper to create a mapping from the 'Pokemon' class to the 'PokemoDto' class. It will automatically copy property values from the source object to the destination object based on property names and types.
        }
    }
}
