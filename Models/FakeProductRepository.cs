using System.Collections.Generic;
using System.Linq;


namespace NosokFun.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name = "Footbal", Price = 25},
            new Product {Name = "Surf ball", Price = 179},
            new Product {Name = "Running shoes", Price = 95},
        }.AsQueryable<Product>();
    }
}