using RestWithASPNETDarlan.Model;

namespace RestWithASPNETDarlan.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        void Delete(long id);
    }
}
