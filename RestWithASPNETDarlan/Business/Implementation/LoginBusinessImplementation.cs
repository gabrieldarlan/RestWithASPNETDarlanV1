using RestWithASPNETDarlan.Configurations;
using RestWithASPNETDarlan.Data.VO;
using RestWithASPNETDarlan.Repository;
using RestWithASPNETDarlan.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestWithASPNETDarlan.Business.Implementation
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        private IUserRepository _userRepository;

        private readonly ITokenService _tokenService;

        private readonly TokenConfiguration _configuration;

        public LoginBusinessImplementation(IUserRepository userRepository, ITokenService tokenService, TokenConfiguration configuration)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public TokenVO ValidateCredentials(UserVO userVo)
        {
            var user = _userRepository.ValidateCredentials(userVo);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.Username)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);
            _userRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);



            return new TokenVO(
                    true,
                    createDate.ToString(DATE_FORMAT),
                    expirationDate.ToString(DATE_FORMAT),
                    accessToken,
                    refreshToken
                );
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var userName = principal.Identity.Name;

            var user = _userRepository.ValidateCredentials(userName);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return null;
            }

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _userRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);



            return new TokenVO(
                    true,
                    createDate.ToString(DATE_FORMAT),
                    expirationDate.ToString(DATE_FORMAT),
                    accessToken,
                    refreshToken
                );

        }
    }
}
