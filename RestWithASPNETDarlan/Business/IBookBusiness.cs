using RestWithASPNETDarlan.Data.VO;
using RestWithASPNETDarlan.Model;

namespace RestWithASPNETDarlan.Business
{
    public interface IBookBusiness
    {
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        void Delete(long id);


    }
}
