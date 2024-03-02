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
        PersonVO Disabled(long id);
        void Delete(long id);
    }
}
