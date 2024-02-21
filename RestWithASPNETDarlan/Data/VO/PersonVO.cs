using System.Text.Json.Serialization;

namespace RestWithASPNETDarlan.Data.VO
{
    public class PersonVO
    {
        [JsonPropertyName("codigo_id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonIgnore]
        public string Address { get; set; }
        [JsonPropertyName("sex")]
        public string Gender { get; set; }
    }
}
