
using PeopleManager.Ui.Mvc.Domain;

namespace PeopleManager.Ui.Mvc.Contracts
{
    public interface IPersonService
    {
        public IReadOnlyList<Person> Find();
        public Person? Get(int id);
        public Person Create(Person person);
        public Person? Update(int id, Person person);
    }
}
