namespace PokemonReviewApp.Models
{
    public class Notes
    {
    //-----------Creation of DataContext steps-------------//
    //Creation of data context , bring in information to manipulate the database tables for quick access. 
    //Setting DB to DataContext, setting many to many relationships to the database tables.

    /*Then inside DataContext, when working with many-to-many tables, 
     * we need to use on-model-creation for manipulation in order to customize the db without going into the db(OnModelCreation) and this is done when we're
     * working with entity framework construction. 
     * We need this customization in order so that people would understand what customizations I did to it. Manipulation of tables would be advantagous.
     * Linkning entities displaying many to many relationships in entity while adding foreign and primary keys.*/

    //------ Program File Setup------//

    //After, we worked on program file setup, by adding our DBcontext<DataContext> we are using db builder service to bring in the SQL server into the program along with our connection string . 
    //This allows us to reach into our app setting JSON & pulls out our connection string.

    //----- Seeding DataBase ----//
    /*After all this is completed, we seed our database, process of populating the database with intial data. Since I started the API it was empty, but since 
     * seeding is crucial for this part of API creating, it insertss predefined data into PokemonAPI DB such as our properties that were created.
     * Seeding this DB is done in the initialization phase , ensures our application has data to work with in the beginning. This is useful for testing and 
     * development purposes as well providing a starting point for users who interact with the API.
     */
    /* After scripting into seeding class, went back into the program.cs file, we wire it up with dependency injection, bringing it inside the program. AddTransient was
     * injected in the very beginning. Under 'var app = builder.Build();' we added a service injection and it seeds the datacontext before the app starts 

    }
}
