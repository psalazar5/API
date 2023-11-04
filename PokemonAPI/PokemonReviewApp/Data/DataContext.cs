using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) //shoves all data context from outside existing classes where your inheriting into entityframework 
        {
            
        } 
        //explaining what our tables/models are into this dbcontext 
        public DbSet<Category> Categories { get; set; } //DbSet (when doing DbContext)
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        //EntityFramework many-many relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Manipulating of tables , modelcreating /customizing tables instead of going into DB , customization so it is more advantagous 
        { //modelbuilder - responsible for construction of db model in ef.
            modelBuilder.Entity<PokemonCategory>() //haskey is configuring the composite key for 'PokemonCategory' entity in ef.Composite key consists of two ro more columns in a table, in this table its 'PokemonId' & 'CategoryId'
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId }); //tells ef, we need to link these two id's   together otherwise ef wont know we want to link them together. 
             
            modelBuilder.Entity<PokemonCategory>() //many-many manipulation
                .HasOne(p => p.Pokemon) //Configures the relationship from 'PokemonCategory' to 'Pokemon' entity.
                .WithMany(pc => pc.PokemonCategories) //Specifies pc in relation to 'Category' entity. Indicates that each entry in pc is associated with one or more 'category' entities throughout navigation property 'pc ' in the 'Category' entity.
                .HasForeignKey(c => c.PokemonId); // Indicates CetegoryId prop in PC entity is a foreign key to reference the PK of 'Category' Entity.

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Category) //configures a relationship from, 'PokemonCategory'
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonOwner>()
                .HasKey(po => new { po.PokemonId, po.OwnerId }); //configures the composite key 'PokemonOwner', using both 'PokemonId' 'OwnerId'

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(po => po.PokemonOwners)
                .HasForeignKey(p => p.PokemonId);

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Owner)
                .WithMany(po => po.PokemonOwners)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
