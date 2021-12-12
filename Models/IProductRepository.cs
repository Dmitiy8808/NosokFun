using System.Linq;

namespace NosokFun.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products {get;}
    }
}