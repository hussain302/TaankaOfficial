using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taanka.DataAccess;
using Taanka.Interfaces;
using Taanka.Models.DomainModels;

namespace Taanka.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TaankaContext context;

        public ProductRepository(TaankaContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product model)
        {
            try
            {
                if (model != null && model.Title != null && model.Category != null && model.SubCategory != null && model.Department != null)
                {
                    context.Add<Product>(model);
                    context.SaveChanges();
                }
            }
            catch
            {

            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                if (id > 0)
                {
                    var product = context.Find<Product>(id);
                    return product;

                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null)
        {
            IQueryable<Product> query = context.Products;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public List<Product> GetProducts(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, params Expression<Func<Product, object>>[] includes)
        {
            IQueryable<Product> query = context.Set<Product>();

            foreach (Expression<Func<Product, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public List<Product> GetProducts()
        {
            try
            {
                var products = context.Products.ToList();
                return products;
            }
            catch
            {
                return null;
            }
        }

        public void RemoveProduct(int id)
        {
            try
            {
                if (id > 0)
                {
                    var find = GetProduct(id);
                    context.Remove(find);
                    context.SaveChanges();
                }
            }
            catch
            {

            }
        }

        public void UpdateProduct(Product model)
        {
            if (model != null && model.Title != null && model.Category != null && model.SubCategory != null && model.Department != null)
            {
                context.Update<Product>(model);
                context.SaveChanges();
            }
        }
    }
}
