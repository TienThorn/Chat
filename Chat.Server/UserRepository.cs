using Chat.Shared;

namespace Chat.Server
{
    public class UserRepository
    {
        public UserRepository()
        {

        }

        public UserRepository(IEnumerable<string> users)
        {
            Users = users.ToList();
        }

        public List<string> Users { get; set; }

        private void AddUser(string user)
        {
            Users.Add(user);
        }

        private void RemoveUser(string user)
        {
            Users.Remove(user);
        }

        public void Login(string user)
        {
            AddUser(user);
        }

        public void Logout(string user)
        {
            RemoveUser(user);
        }
    }
}
