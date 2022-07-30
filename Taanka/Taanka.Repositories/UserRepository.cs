using Microsoft.EntityFrameworkCore;
using Taanka.DataAccess;
using Taanka.Interfaces;
using Taanka.Models.DomainModels;

namespace Taanka.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaankaContext context;

        public UserRepository(TaankaContext context)
        {
            this.context = context;
        }



        public void AddUser(User model)
        {
            try
            {
                var role = GetRoleByName("admin");
                model.RoleId = role.Id;
                model.IsActive = false;
                if (model != null && model.Email != null && model.LoginId != null && model.Password != null)
                {
                    context.Add<User>(model);
                    context.SaveChanges();
                }
            }
            catch
            {

            }
        }

        public void ApproveUser(User model)
        {
            try
            {
                if(model != null)
                {
                    model.IsActive = true;
                    context.Update<User>(model);
                    context.SaveChanges();
                }
            }
            catch {  }
        }

        public Role GetRole(int id)
        {
            try
            {
                return context.Roles.Where(x => x.Id == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public Role GetRoleByName(string name)
        {
            try
            {
                return context.Roles.Where(x => x.Name == name).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public List<Role> GetRoles()
        {
            try
            {
                return context.Roles.ToList();
            }
            catch
            {
                return null;
            }
        }

        public User GetUser(string loginid, string password)
        {
            try
            {
                var findUser = (from u in context.Users.Include(x => x.Role)
                                where u.LoginId == loginid && u.Password == password
                                select u).FirstOrDefault();

                if (findUser != null) return findUser;
                else return null;
            }
            catch
            {
                return null;
            }
        }

        public User GetUser(int id)
        {
            try
            {
                return context.Users.Where(x => x.Id == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public User GetUser(string loginid)
        {
            try
            {
                var findUser = (from u in context.Users.Include(x => x.Role)
                                where u.LoginId == loginid
                                select u).FirstOrDefault();

                if (findUser != null) return findUser;
                else return null;
            }
            catch
            {
                return null;
            }
        }

        public List<User> GetUsers()
        {
            var list = (from u in context.Users
                        .Include("Role")
                              select u).ToList();

            if (list.Count == 0) return null;
            else return list;
        }

        public void RemoveUser(int id)
        {
            try
            {
                if (id > 0)
                {
                    var find = context.Users.Find(id);
                    context.Users.Remove(find);
                    context.SaveChanges();
                }
            }
            catch { }
        }

        public void UpdateUser(User model)
        {
            try
            {
                if(model!=null && model.Email != null && model.LoginId != null && model.Password != null)
                {
                    context.Update<User>(model);
                    context.SaveChanges();
                }
            }
            catch { }
        }
    }
}