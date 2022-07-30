using Taanka.Models.DomainModels;
using Taanka.Models.WebModels;

namespace Taanka.Mappers
{
    public static class ProductMappers
    {
        public static ProductModel ToModel(this Product source)
        {
            return new ProductModel
            {
                Id = source.Id,
                Category = source.Category,
                Colors = source.Colors,
                Department = source.Department,
                Description = source.Description,
                Fabric = source.Fabric,
                Image_url_path = source.Image_url_path,
                IsTrending = source.IsTrending,
                Price = source.Price,
                Sizes = source.Sizes,
                SubCategory = source.SubCategory,
                Title = source.Title,
            };
        }

        public static Product ToDB(this ProductModel source)
        {
            return new Product
            {
                Id = source.Id,
                Category = source.Category,
                Colors = source.Colors,
                Department = source.Department,
                Description = source.Description,
                Fabric = source.Fabric,
                Image_url_path = source.Image_url_path,
                IsTrending = source.IsTrending,
                Price = source.Price,
                Sizes = source.Sizes,
                SubCategory = source.SubCategory,
                Title = source.Title,
            };
        }
    }
}