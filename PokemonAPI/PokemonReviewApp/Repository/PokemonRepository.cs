using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository //inherting IPokemon Interface 
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault(); //'where' filtering an sql/ programming abstraction of sql, goes into our Pokemon entity and searches for the column with the pokeId -firstordeault shows first entity is going to find.
        }//^this returns one 

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault(); //searching by the name 
        }

        public decimal GetPokemonRating(int pokeId) //this retrieves user reviews for a specific pokemon, checks for any rviews and calculates the average rating based on the rating provided by users. 
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId); //returns a collection of reviews from data context 
            //it filters reviews where the 'Pokemon.Id' matches the provided 'pokeId', which means it selects all reviews for a particular Pokemon with the Id specified in the 'pokeId' parameter.
            if(review.Count() <= 0) //checks if there are reviews in the 'review' collection 
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count()); //calculates average rating of a Pokemon (conversion).
        } //^ if there are reviews it calculates it.

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList(); //ordering / manipulation 
        } //returns a list, need to chain on .ToList() or it is going to cause more errors in program  

        public bool PokemonExist(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId);
        }
    } 
}
