using PersonApp.Data;
using PersonApp.Interfaces;
using PersonApp.Model;

namespace PersonApp.Repository
{
    public class PersonTypeRepository : IPersonTypeInterface
    {
        private readonly DataContext _context;

        public PersonTypeRepository(DataContext context)
        {
            this._context = context;
        }

        public ICollection<PersonType> GetPersonTypes()
        {
                return _context.PersonTypes.OrderBy(p => p.Type).ToList();
        }
        public PersonType GetPersonType(int id)
        {
            return _context.PersonTypes.FirstOrDefault(pt => pt.Type == id);
        }

        public PersonType CreatePersonType(PersonType persontype)
        {
            _context.PersonTypes.Add(persontype);
            _context.SaveChanges();
            return persontype;
        }
        public PersonType UpdatePersonType(int id, PersonType oldpersontype, PersonType newpersontype)
        {
            var newPersonType = _context.PersonTypes.FirstOrDefault(pt => pt.Type == id);
            newPersonType.Description = newpersontype.Description;

            _context.PersonTypes.Update(newPersonType);
            _context.SaveChanges();
            return newPersonType;
        }

        public bool DeletePersonType(int id)
        {
            var personTypeToDelete = _context.PersonTypes.FirstOrDefault(pt => pt.Type == id);
            if (personTypeToDelete == null)
            {
                return false;
            }
            _context.PersonTypes.Remove(personTypeToDelete);
            _context.SaveChanges();
            return true;
        }


    }
}
