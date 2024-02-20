using RestWithASPNETDarlan.Model;
using RestWithASPNETDarlan.Repository.Generic;

namespace RestWithASPNETDarlan.Business.Implementation
{
    public class BookBusinessImplementation : IBookBusiness
    {

        private readonly IRepository<Book> _repository;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
