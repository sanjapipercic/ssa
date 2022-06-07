using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductRepository productRepository;
        public ProductBusiness (IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = this.productRepository.GetAllProducts();
            if(products.Count > 0)
            {
                return products;
            }
            else
            {
                return null;
            }
        }

        public bool InsertProduct(Product product)
        {
            if(this.productRepository.InsertProduct(product) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Product> GetMinMaxPriceProducts(int minprice, int maxprice)
        {
            List<Product> products = this.productRepository.GetAllProducts();
            return products.FindAll(p => p.Price >= minprice && p.Price <= maxprice);
        }

        public bool UpdateProduct(UpdateProductDTO p, int id)
        {
            if(id != 0 && this.productRepository.UpdateProduct(p, id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            if(id != 0 && this.productRepository.DeleteProduct(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
