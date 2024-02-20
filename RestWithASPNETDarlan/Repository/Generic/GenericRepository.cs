using Microsoft.EntityFrameworkCore;
using RestWithASPNETDarlan.Model;
using RestWithASPNETDarlan.Model.Base;
using RestWithASPNETDarlan.Model.Context;

namespace RestWithASPNETDarlan.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly MySQLContext _context;

        private readonly DbSet<T> _dataSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }


        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(long id)
        {
            return _dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Update(T item)
        {
            var result = _dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _dataSet.Entry(result).CurrentValues.SetValues(item) ;
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = _dataSet.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        private bool Exists(long id)
        {
            return _dataSet.Any(p => p.Id.Equals(id));
        }
    }
}
