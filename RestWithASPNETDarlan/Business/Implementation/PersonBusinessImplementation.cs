using RestWithASPNETDarlan.Data.Converter.Implementations;
using RestWithASPNETDarlan.Data.VO;
using RestWithASPNETDarlan.Model;
using RestWithASPNETDarlan.Repository;

namespace RestWithASPNETDarlan.Business.Implementation
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO? FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }


        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }


        public void Delete(long id)
        {
            _repository.Delete(id);

        }

        public PersonVO Disabled(long id)
        {
            var personEntity=_repository.Disabled(id);
            return _converter.Parse(personEntity);
        }
    }
}
