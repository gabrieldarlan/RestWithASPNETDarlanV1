using System.Text.Json.Serialization;

namespace RestWithASPNETDarlan.Data.VO
{
    public class PersonVO
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }
    }
}
