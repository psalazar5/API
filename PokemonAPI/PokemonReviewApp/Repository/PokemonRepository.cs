using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository //inherting IPokemon Interface , means that it must implement methods declared in that interface. Interface defines the contract that this repository must follow.
    {
        private readonly DataContext _context; //readonly field can only be assigned a value in class's constructor, and once assigned it cannot be changed. 
        //DataContext _context suggests it is an instance of the DataContext class , is typically used to interact with a database or source.
       
        public PokemonRepository(DataContext context) //instance of data context, is used to interact with data source 
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id) //overload method to retrieve a Pokemon by its ID 
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault(); //'where' filtering an sql/ programming abstraction of sql, goes into our Pokemon entity and searches for the column with the pokeId -firstordeault shows first entity is going to find.
        }//^this returns one. 

        public Pokemon GetPokemon(string name) //retrieves pokemon by name 
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault(); //searching by the name 
        }

        public decimal GetPokemonRating(int pokeId) //this retrieves user reviews for a specific pokemon, checks for any reviews and calculates the average rating based on the rating provided by users. 
        { //retrieves a collection of all pokemon entities from the data source 
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

        public bool PokemonExist(int pokeId) //Method checks whether pokemon exists with the specified 'pokeId' in the data source. 
        {
            return _context.Pokemon.Any(p => p.Id == pokeId); // it uses 'any' method to detmine if any Pokemon has the provided id. 
        }
    } 
}
