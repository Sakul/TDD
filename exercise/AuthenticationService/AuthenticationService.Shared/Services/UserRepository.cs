using AuthenticationService.Shared.Models;

namespace AuthenticationService.Shared.Services
{
    public class UserRepository
    {
        private IList<UserInfo> _users;

        public UserRepository()
        {
            _users = new List<UserInfo>();
            addNewUser();
            addNewUser();
            addNewUser();
            addNewUser();
            addNewUser();

            void addNewUser()
            {
                var id = Guid.NewGuid().ToString();
                var newUser = new UserInfo
                {
                    Id = id,
                    DisplayName = $"Admin {_users.Count()}",
                    Username = $"admin{_users.Count()}",
                    Password = "P@ssw0rd",
                };
                _users.Add(newUser);
            }
        }

        public virtual async Task<IEnumerable<UserInfo>> GetAllUsers()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            return _users;
        }

        public virtual async Task UpdateUserToken(string userId, string token)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            var selectedUser = _users.FirstOrDefault(it => it.Id == userId);
            selectedUser.ActiveToken = token;
        }
    }
}
