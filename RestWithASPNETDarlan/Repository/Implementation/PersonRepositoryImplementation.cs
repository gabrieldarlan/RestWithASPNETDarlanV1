using RestWithASPNETDarlan.Model;
using RestWithASPNETDarlan.Model.Context;
using System;

namespace RestWithASPNETDarlan.Repository.Implementation
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private readonly MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }


        public Person? FindById(long id)
        {
            try
            {
                return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message); 
            }
        }


        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return person;
        }


        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

        }
        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
