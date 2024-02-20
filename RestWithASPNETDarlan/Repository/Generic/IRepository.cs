using RestWithASPNETDarlan.Model;
using RestWithASPNETDarlan.Model.Base;

namespace RestWithASPNETDarlan.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        List<T> FindAll();
        T FindById(long id);
        void Delete(long id);
    }
}
