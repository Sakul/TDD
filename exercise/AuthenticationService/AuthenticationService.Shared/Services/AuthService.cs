namespace AuthenticationService.Shared.Services
{
    public class AuthService
    {
        public UserRepository UserRepo { get; set; }

        public AuthService()
            => UserRepo = new UserRepository();

        public async Task<string> Login(string username, string password)
        {
            var users = await UserRepo.GetAllUsers();
            var selectedUser = users.FirstOrDefault(it => it.Username == username && it.Password == password);
            if (null == selectedUser) return null;

            var token = Guid.NewGuid().ToString();
            await UserRepo.UpdateUserToken(selectedUser.Id, token);
            return token;
        }

        public async Task<bool> Logout(string userToken)
        {
            var users = await UserRepo.GetAllUsers();
            var selectedUser = users.FirstOrDefault(it => it.ActiveToken == userToken);
            if (null == selectedUser) return false;

            await UserRepo.UpdateUserToken(selectedUser.Id, null);
            return true;
        }
    }
}
