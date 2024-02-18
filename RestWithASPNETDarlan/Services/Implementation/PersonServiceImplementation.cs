using RestWithASPNETDarlan.Model;

namespace RestWithASPNETDarlan.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }


        public Person FindById(long id)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "Darlan",
                LastName = "Silva",
                Address = "Osasco - Suiça",
                Gender = "Non Binary"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person Last" + i,
                Address = "Some address" + i,
                Gender = "Non Binary" + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
