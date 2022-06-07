using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IProductBusiness
    {
        List<Product> GetAllProducts();

        bool InsertProduct(Product product);
        List<Product> GetMinMaxPriceProducts(int minprice, int maxprice);
        bool UpdateProduct(UpdateProductDTO p, int id);
        bool DeleteProduct(int id);
    }
}
