using System.Linq.Expressions;
using Taanka.Models.DomainModels;

namespace Taanka.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public Product GetProduct(int id);
        public void AddProduct(Product model);
        public void RemoveProduct(int id);
        public void UpdateProduct(Product model);
        public IEnumerable<Product> GetProducts(
           Expression<Func<Product, bool>> filter = null,
           Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null);

        public List<Product> GetProducts(Expression<Func<Product, bool>> filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            params Expression<Func<Product, object>>[] includes);
    }
}