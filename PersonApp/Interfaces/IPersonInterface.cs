using PersonApp.Model;

namespace PersonApp.Interfaces
{
    public interface IPersonInterface
    {
        ICollection<Person> GetPersons();
        Person GetPerson(int id);
        Person CreatePerson(Person person);
        Person UpdatePerson(int id, Person oldperson, Person newperson);
        bool DeletePerson(int id);


    }
}