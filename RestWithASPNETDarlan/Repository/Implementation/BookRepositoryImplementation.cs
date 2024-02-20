using RestWithASPNETDarlan.Model;
using RestWithASPNETDarlan.Model.Context;
using System;

namespace RestWithASPNETDarlan.Repository.Implementation
{
    public class BookRepositoryImplementation : IBookRepository
    {

        private readonly MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book? FindById(long id)
        {
            try
            {
                return _context.Books.SingleOrDefault(b => b.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
     
        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        public Book? Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return book;
        }

        private bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}
