namespace PokemonReviewApp.Models
{
    public class Notes
    {
        //---------Creation of DataContext steps-----------//

        //Creation of data context, bring in information to manipulate the database tables for quick access. 
        //Setting DB to DataContext, setting many to many relationships to the database tables.

        /*Then inside DataContext, when working with many-to-many tables, we need to use on-model-creation for manipulation in order to customize the 
         * db without going into the db(OnModelCreation) and this is done when we're working with entity framework construction. 
         * We need this customization in order so that people would understand what customizations I did to it. Manipulation of tables would be advantagous.
         * Linkning entities displaying many to many relationships in entity while adding foreign and primary keys.*/

        //------ Program File Setup------//

        //After, we worked on program file setup, by adding our DBcontext<DataContext> we are using db builder service to bring in the SQL server into the program along with our connection string. 
        //This allows us to reach into our app setting JSON & pulls out our connection string.


         //----- Seeding DataBase ----//

        /*After all this is completed, we seed our database, process of populating the database with intial data. Starting the API resulted in it being empty, but since 
         * seeding is crucial for this part of API creation, it inserts predefined data into PokemonAPI DB such as our properties that were created.
         * Seeding this DB is done in the initialization phase, ensures our application has data to work with in the beginning. This is useful for testing and 
         * development purposes as well as providing a starting point for users who interact with the API.
         */

        //------ Dependency Injection ------//

        /* After scripting into seeding class, went back into the program.cs file, we wire it up with dependency injection, bringing it inside the program. AddTransient was
         * injected in the very beginning. Under 'var app = builder.Build();' we added a scope (service injection and it seeds the datacontext before the app starts, deals with arguments when starting).
         */

        //-- Creating Database - adding migration --//

        /* Migration creates code that generates SQL queries for the database. Entity Framework employs migrations. 
         * Initially, 'Add-Migration InitialCreate' was intended in the Package Manager Console. It establishes tables in the database. 'Update-database' confirms the database. 
         * Suddenly, 'Update-Database' did not work for its specific reasons so troubleshooting again, this command confirms the DB 'dotnet ef database update --context DataContext --project C:\Users\psala\SoftwareDevelopment\API\PokemonAPI\PokemonReviewApp'
         * Facing issues, I installed 'Install-Package Microsoft.EntityFrameworkCore', 'dotnet tool install --global dotnet ef' for 'dotnet ef' tool.
         * 'Add-Migration' failed due to Entity Framework Core tools' specificity. After troubleshooting, I learned Entity Framework Core tools use 'dotnet ef' for migrations.
         * Ultimately, the correct command was 'dotnet ef migrations add InitialCreate --context DataContext --project C:\Users\psala\SoftwareDevelopment\API\PokemonAPI\PokemonReviewApp'.
         * 
         * Migrations in Entity Framework Core are a way to manage database schema changes over time while preserving existing data. They enable you to make changes to your data model (such as adding new tables or columns) and update the database accordingly.
         * 'dotnet ef migrations add InitialCreate --context DataContext --project C:\Users\psala\SoftwareDevelopment\API\PokemonAPI\PokemonReviewApp'
         * tells Entity Framework to generate the necessary code for creating the database schema corresponding to the DataContext class in your PokemonReviewApp project. 
         * Once the migration is ran, it'll be available to apply the changes to the database using the dotnet ef database update command.
         * Overall, this process enabled me to evolve the database schema alongside the application's development without manually managing SQL scripts.
   
         * AFTER - we run the database seed in .net run using terminal. Using the terminal we go into the right folder by using the commands in order to run the DB which is 'cd PokemonReviewApp' into another folder which holds csproj.
         * using 'dir' we review our project then run another command 'dotnet run seeddata' to run database seed. After command has passed through seeding the DB we go back into SSMS and review our completed databases.
         * 
         */


        //--   --//
    }
}
