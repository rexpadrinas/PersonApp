using PersonApp.Model;

namespace PersonApp.Interfaces
{
    public interface IPersonTypeInterface
    {
        ICollection<PersonType> GetPersonTypes();
        PersonType GetPersonType(int id);
        PersonType CreatePersonType(PersonType persontype);
        PersonType UpdatePersonType(int id, PersonType oldpersontype, PersonType newpersontype);
        bool DeletePersonType(int id);


    }
}
