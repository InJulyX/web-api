namespace Web.Model
{
    public class JwtSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
        public int ExpiredTime { get; set; }
    }
}