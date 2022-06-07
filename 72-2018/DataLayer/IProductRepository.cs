﻿using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        int InsertProduct(Product product);

        int UpdateProduct(UpdateProductDTO p, int id);
        int DeleteProduct(int id);
    }
}
