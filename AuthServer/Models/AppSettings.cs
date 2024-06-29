namespace AuthServer.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiryTimeInMinutes { get; set; }
    }
}
