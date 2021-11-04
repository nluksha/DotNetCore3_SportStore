using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;

        public IQueryable<Product> Products => context.Products;

        public EFStoreRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public void SaveProduct(Product p)
        {
            context.SaveChanges();
        }

        public void CreateProduct(Product p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
    }
}
