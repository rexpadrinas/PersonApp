using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PersonApp.Data;
using PersonApp.Interfaces;
using PersonApp.Model;

namespace PersonApp.Repository
{
    public class PersonRepository : IPersonInterface
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            this._context = context;
        }
        public ICollection<Person> GetPersons()
        {
            return _context.Persons.OrderBy(p => p.ID).ToList();

        }
        public Person GetPerson(int id) 
        {
            return _context.Persons.FirstOrDefault(pt => pt.ID == id);
        }

        public Person CreatePerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }
        public Person UpdatePerson(int id, Person oldperson, Person newperson)
        {
            var newPerson =  _context.Persons.FirstOrDefault(pt => pt.ID == id);
            newPerson.Name = newperson.Name;
            newPerson.Age = newperson.Age;
            newPerson.TypeID = newperson.TypeID;

            _context.Persons.Update(newPerson);
            _context.SaveChanges();
            return newPerson;
        }

        public bool DeletePerson(int id)
        {
            var personToDelete = _context.Persons.FirstOrDefault(pt => pt.ID == id);
            if (personToDelete == null)
            {
                return false;
            }
            _context.Persons.Remove(personToDelete);
            _context.SaveChanges();
            return true;
        }

    }
}
