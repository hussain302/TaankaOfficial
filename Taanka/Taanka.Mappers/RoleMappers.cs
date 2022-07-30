using Taanka.Models.DomainModels;
using Taanka.Models.WebModels;

namespace Taanka.Mappers
{
    public static class RoleMappers
    {
        public static RoleModel ToModel(this Role source)
        {
            return new RoleModel
            {
                Name = source.Name,
                Id  = source.Id
            };
        }
        
        public static Role ToDB(this RoleModel source)
        {
            return new Role
            {
                Name = source.Name,
                Id  = source.Id
            };
        }

    }
}