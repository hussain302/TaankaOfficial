using Taanka.Models.DomainModels;

namespace Taanka.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
        public User GetUser(string loginid, string password);
        public User GetUser(string loginid);
        public User GetUser(int id);
        public List<Role> GetRoles();
        public void AddUser(User model);
        public void UpdateUser(User model);
        public Role GetRole(int id);
        public Role GetRoleByName(string name);
        public void ApproveUser(User model);
        public void RemoveUser(int id);

    }
}
