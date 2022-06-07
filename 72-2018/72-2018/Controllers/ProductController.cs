using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _72_2018.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBusiness productBusiness;
        public ProductController(IProductBusiness productBusiness)
        {
            this.productBusiness = productBusiness;
        }

        [HttpGet("getall")]
        public List<Product> GetAllProducts()
        {
            return this.productBusiness.GetAllProducts();
        }

        [HttpPost("insert")]
        public bool InsertProduct([FromBody] Product product)
        {
            return this.productBusiness.InsertProduct(product);
        }

        [HttpGet("{minprice}/{maxprice}/get")]
        public List<Product> GetMinMaxProduct(int minprice, int maxprice)
        {
            return this.productBusiness.GetMinMaxPriceProducts(minprice, maxprice);
        }

        [HttpPut("update/{id}")]
        public bool UpdateProduct([FromBody] UpdateProductDTO product, int id)
        {
            return this.productBusiness.UpdateProduct(product, id);
        }
        [HttpDelete("delete/{id}")]
        public bool DeleteProduct(int id)
        {
            return this.productBusiness.DeleteProduct(id);
        }
    }
}
