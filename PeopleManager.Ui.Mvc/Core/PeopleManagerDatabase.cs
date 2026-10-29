using Microsoft.EntityFrameworkCore;
using PeopleManager.Ui.Mvc.Domain;

namespace PeopleManager.Ui.Mvc.Core
{
    // Alleen leesbewerkingen in deze les. Geen echte database.
    public class PeopleManagerDatabase(DbContextOptions<PeopleManagerDatabase> options)
        :DbContext(options)
    {
    
        public DbSet<Person> People => Set<Person>();

        // Aanroepen tijdens het opstarten, voor de registratie.
        public void Initialize()
        {
            var people = new List<Person>
            {
                new() { Id = 1, FirstName = "Noor", LastName = "Peeters", Email = "noor@example.com" },
                new() { Id = 2, FirstName = "Adam", LastName = "Janssens", Email = null },
                new() { Id = 3, FirstName = "Lina", LastName = "Dubois", Email = "lina@example.com" },
                new() { Id = 4, FirstName = "Milan", LastName = "Willems", Email = null },
                new() { Id = 5, FirstName = "Emma", LastName = "Maes", Email = "emma@example.com" }
            };

            People.AddRange(people);

            SaveChanges();
        }
    }
}
