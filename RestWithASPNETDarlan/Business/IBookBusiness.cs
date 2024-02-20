using RestWithASPNETDarlan.Model;

namespace RestWithASPNETDarlan.Business
{
    public interface IBookBusiness
    {
        Book FindById(long id);
        List<Book> FindAll();
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);


    }
}
