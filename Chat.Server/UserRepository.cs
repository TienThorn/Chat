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

        public void Login(string newUser)
        {
            if (Users.Count == 0) 
            {
                AddUser(newUser);
            }
            else 
            {
                foreach (string user in Users.ToList())
                {
                    if (newUser == user)
                    {
                        RemoveUser(newUser);
                        break;
                    }
                    AddUser(newUser);
                }
            }     
        }

        public void Logout(string newUser)
        {
            if (Users.Count == 0)
            {
                AddUser(newUser);
            }
            else
            {
                foreach (string user in Users)
                {
                    if (newUser == user)
                    {
                        RemoveUser(newUser);
                        break;
                    }
                    AddUser(newUser);
                }
            }
        }
    }
}
