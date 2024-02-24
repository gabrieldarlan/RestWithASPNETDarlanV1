using RestWithASPNETDarlan.Data.VO;
using RestWithASPNETDarlan.Model;
using RestWithASPNETDarlan.Model.Context;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNETDarlan.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User? ValidateCredentials(UserVO user)
        {

            var pass = ComputeHash(user.Password, SHA256.Create());
            return _context.Users.FirstOrDefault(u => (u.Username == user.Username) && (u.Password == u.Password));
        }


        public User? Update(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;


            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return result;
        }


        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            var builder = new StringBuilder();

            foreach (var item in hashedBytes)
            {
                builder.Append(item.ToString("x2"));
            }


            return builder.ToString();
        }
    }
}
