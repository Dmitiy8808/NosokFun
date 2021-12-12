using System.Collections.Generic;
using NosokFun.Models;

namespace NosokFun.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products {get; set;}
        public PagingInfo PagingInfo {get; set;}
    }
}