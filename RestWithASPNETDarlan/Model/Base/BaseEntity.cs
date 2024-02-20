using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETDarlan.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
