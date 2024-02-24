using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETDarlan.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions options) : base(options)
        {
        }

        protected MySQLContext()
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
