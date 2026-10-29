using PeopleManager.Ui.Mvc.Contracts;
using PeopleManager.Ui.Mvc.Core;
using PeopleManager.Ui.Mvc.Domain;

namespace PeopleManager.Ui.Mvc.Services
{
    public class InMemoryPersonService(PeopleManagerDatabase database) : IPersonService
    {
        public IReadOnlyList<Person> Find()
        {
            return database.People.ToList();
        }

        public Person? Get(int id)
        {
            return database.People.FirstOrDefault(p => p.Id == id);
        }

        public Person Create(Person person)
        {
            database.People.Add(person);
            database.SaveChanges();
            return person;
        }

        public Person? Update(int id, Person person)
        {
            var personToUpdate = database.People
                .FirstOrDefault(p => p.Id == id);

            if (personToUpdate is null)
            {
                return null;
            }

            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.Email = person.Email;

            database.SaveChanges();

            return personToUpdate;
        }
    }
}
