using RestWithASPNETDarlan.Data.VO;

namespace RestWithASPNETDarlan.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
    }
}
