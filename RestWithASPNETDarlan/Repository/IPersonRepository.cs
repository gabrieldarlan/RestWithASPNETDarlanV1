using RestWithASPNETDarlan.Model;

namespace RestWithASPNETDarlan.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        void Delete(long id);
    }
}
