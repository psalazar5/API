namespace PokemonReviewApp.Models
{
    public class Pokemon
    { //model is your db tables , DB is like excel spreadsheet. 
        public int Id { get; set; } //almost like a column
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Review> Reviews  { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}
