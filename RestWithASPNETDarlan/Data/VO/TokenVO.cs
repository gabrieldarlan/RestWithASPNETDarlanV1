namespace RestWithASPNETDarlan.Data.VO
{
    public class TokenVO
    {
        public bool? Authenticaded { get; set; }
        public string? Created { get; set; } 
        public string? Expiration { get; set; } 
        public string? AccessToken { get; set; } 
        public string? RefreshToken { get; set; }

        public TokenVO(bool? authenticaded, string? created, string? expiration, string? accessToken, string? refreshToken)
        {
            Authenticaded = authenticaded;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
