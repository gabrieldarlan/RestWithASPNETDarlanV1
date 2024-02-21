using RestWithASPNETDarlan.Data.VO;
using RestWithASPNETDarlan.Model;

namespace RestWithASPNETDarlan.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        void Delete(long id);
    }
}
