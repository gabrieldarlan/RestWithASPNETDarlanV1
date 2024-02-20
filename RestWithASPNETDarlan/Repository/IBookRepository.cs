using RestWithASPNETDarlan.Model;

namespace RestWithASPNETDarlan.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book Update(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        void Delete(long id);
    }
}
