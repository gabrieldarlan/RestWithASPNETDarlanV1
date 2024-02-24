using RestWithASPNETDarlan.Data.VO;
using RestWithASPNETDarlan.Model;

namespace RestWithASPNETDarlan.Repository
{
    public interface IUserRepository
    {
        public User? ValidateCredentials(UserVO user);
        public User? Update(User user);

    }
}
