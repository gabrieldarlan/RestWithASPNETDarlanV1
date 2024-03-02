using RestWithASPNETDarlan.Data.VO;
using RestWithASPNETDarlan.Model;
using RestWithASPNETDarlan.Repository.Generic;

namespace RestWithASPNETDarlan.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disabled(long id);
    }
}
