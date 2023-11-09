using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.DTO;
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
        private readonly IPokemonRepository _pokemonRepository; //ensures _pokemonRepository field is set to a specific value when an instance of the 'PokemonControllers' class is created
        //and that value remains constant for the lifetime of that instance. It promotes data integrity and helps prevent unintended changes to the fields value.
        private readonly IMapper _mapper;
        public PokemonControllers(IPokemonRepository pokemonRepository, IMapper mapper) //IPokemon ctor takes IPokemonRepository param , which is an interface representing a repo for managing pokemon data. (Constructor injection promotes loose coupling and modularity )
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet] // action method in controller should respond to http get requests 
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))] //specifying possible http response types & actions it can produce 
        public IActionResult GetPokemons() // Get method is responsible for handling GET requests to retrieve a list of pokemon, it calls the _pokemonRepo method to fetch Pokemon data.
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons()); //brings in our code from PokemonRepository.cs
            //_mapper.Map used AutoMapper to map the list of the pokemon models to a list of PokemonDto models. Allows to return Dto's instead of domain models to the client which can control what data is exposed.
            if (!ModelState.IsValid) //if we submitted a wrong data in the wrong context of pokemonapi it will detect that & returns a bad reqeust 
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemon(int pokeId) //IActionResult represents the result of an action method in a controller. 
        {
            if (!_pokemonRepository.PokemonExist(pokeId))
                return NotFound();

            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));// _mapper uses AutoMapper to map the single pokemon model to a PokemonDto model. Allows to return a DTO representing the requested Pokemon.

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExist(pokeId))
                return NotFound();
            var rating = _pokemonRepository.GetPokemonRating(pokeId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }
    }
}
