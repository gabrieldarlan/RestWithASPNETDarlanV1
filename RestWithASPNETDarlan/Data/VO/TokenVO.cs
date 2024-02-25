namespace RestWithASPNETDarlan.Data.VO
{
    public class TokenVO
    {
        public bool Authenticaded { get; set; }
        public string Created { get; set; } = string.Empty;
        public string Expiration { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

        public TokenVO(bool authenticaded, string created, string expiration, string accessToken, string refreshToken)
        {
            Authenticaded = authenticaded;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
