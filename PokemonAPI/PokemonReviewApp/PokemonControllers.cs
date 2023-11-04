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

        [HttpGet] // action method in controller should respond to http get requests 
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))] //specifying possible http response types & actions it can produce 
        public IActionResult GetPokemons() 
        {
            var pokemons = _pokemonRepository.GetPokemons(); //brings in oure code from PokemonRepository.cs

            if (!ModelState.IsValid) //if we submitted a wrong data in the wrong context of pokemonapi it will detect that & returns a bad reqeust 
                return BadRequest(ModelState);

            return Ok(pokemons);
        }
    }
}
