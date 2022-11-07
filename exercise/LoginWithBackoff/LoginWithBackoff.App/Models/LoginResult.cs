namespace LoginWithBackoff.App.Models
{
    public class LoginResult
    {
        public string Token { get; set; }
        public int AttemptCount { get; set; }
        public DateTime CurrentServerTime { get; set; }
        public DateTime? UnlockTime { get; set; }
        public string ErrorMessage { get; set; }
    }
}
