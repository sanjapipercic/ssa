using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ProductRepository : IProductRepository
    {
        private string ConnectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog = ShopDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        

        public List<Product> GetAllProducts()
        {
            List<Product> listToReturn = new List<Product>();
            using(SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT *FROM Products";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.Id = dataReader.GetInt32(0);
                    product.Name = dataReader.GetString(1);
                    product.Description = dataReader.GetString(2);
                    product.Price = dataReader.GetDecimal(3);

                    listToReturn.Add(product);
                }
            }

            return listToReturn;

        }

        public int InsertProduct(Product product)
        {
            using(SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Products VALUES (" +
                    "'" + product.Name + "'" + ", " +
                    "'" + product.Description + "'" + ", " +
                        + product.Price + ")";
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateProduct(UpdateProductDTO p, int id)
        {
            using(SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Products SET " +
                    "Name = " + "'" + p.Name + "'" + ", " +
                    "Description = " + "'" + p.Description + "'" + ", " +
                    "Price = " + p.Price + "WHERE Id = " + id;

                return command.ExecuteNonQuery();
             }
        }
        public int DeleteProduct(int id)
        {
            using(SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM Products WHERE Id = " + id;

                return command.ExecuteNonQuery();
            }
        }
    }
}
