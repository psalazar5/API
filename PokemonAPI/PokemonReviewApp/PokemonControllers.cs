using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
/* Pokemon Controller is responsible for handling HTTP GET requests related to Pokemon data. It uses
 * constructor injection to work with a Pokemon Repo, performs model validation, & returns appropriate responses 
 * based on HTTP requests & data retrieved from repo. It adheres to RESTful principles by defining routes 
 * and using attributes to specify response types. */
namespace PokemonReviewApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonControllers : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonControllers(IPokemonRepository pokemonRepository) //IPokemon ctor takes IPokemonRepository param , which is an interface representing a repo for managing pokemon data. (Constructor injection promotes loose coupling and modularity )
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet] // action method in controller should respond to http get requests 
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))] //specifying possible http response types & actions it can produce 
        public IActionResult GetPokemons() // Get method is responsible for handling GET requests to retrieve a list of pokemon, it calls the _pokemonRepo method to fetch Pokemon data.
        {
            var pokemons = _pokemonRepository.GetPokemons(); //brings in oure code from PokemonRepository.cs

            if (!ModelState.IsValid) //if we submitted a wrong data in the wrong context of pokemonapi it will detect that & returns a bad reqeust 
                return BadRequest(ModelState);

            return Ok(pokemons);
        }
    }
}
