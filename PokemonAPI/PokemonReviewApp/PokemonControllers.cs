using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonControllers : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonControllers(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons() 
        {
            var pokemons = _pokemonRepository.GetPokemons();
        }
    }
}
