using Taanka.Models.DomainModels;
using Taanka.Models.WebModels;

namespace Taanka.Mappers
{
    public static class UserMapper
    {
        public static UserModel ToModel(this User source)
        {
            return new UserModel
            {
                Id = source.Id,
                Email = source.Email,
                LoginId = source.LoginId,
                Name = source.Name,
                Password = source.Password,
                Phone = source.Phone,
                Role = source.Role.ToModel(),
                IsActive = source.IsActive,
            };
        }
        public static User ToDB(this UserModel source)
        {
            return new User
            {
                Id = source.Id,
                Email = source.Email,
                LoginId = source.LoginId,
                Name = source.Name,
                Password = source.Password,
                Phone = source.Phone,
                RoleId = source.RoleId,
                IsActive = source.IsActive
            };
        }

    }
}