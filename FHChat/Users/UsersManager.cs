using System.Collections.Generic;

namespace FHChat.Users
{
    public class UsersManager
    {
        private List<User> users = new List<User>();
        public bool AddUser(User user)
        {
            if (!users.Contains(user))
            {
                users.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveUser(User user)
        {
            if(users.Contains(user))
            {
                users.Remove(user);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<User> GetUsers()
        {
            return this.users;
        }
        public void Clear()
        {
            this.users.Clear();
        }
        public int Count()
        {
            return users.Count;
        }
    }
}