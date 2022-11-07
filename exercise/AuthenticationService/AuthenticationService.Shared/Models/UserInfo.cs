namespace AuthenticationService.Shared.Models
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string ActiveToken { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
