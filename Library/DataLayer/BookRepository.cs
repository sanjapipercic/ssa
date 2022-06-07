using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
    public class BookRepository : IBookRepository
    {
        private string ConnectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=LibraryDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            using(SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Books";

                SqlDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    Book book = new Book();
                    book.Id = dataReader.GetInt32(0);
                    book.Name = dataReader.GetString(1);
                    book.ISBN = dataReader.GetString(2);
                    book.Genre = dataReader.GetString(3);

                    books.Add(book);
                }

            }
            return books;
        }

        public int Insert(Book book)
        {
            using(SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Books VALUES (" +
                    "'" + book.Name + "'" + ", " +
                    "'" + book.ISBN + "'" + ", " +
                    "'" + book.Genre + "'" + ")";
                return command.ExecuteNonQuery();
            }
        }

        public int Update(UpdateBookDTO b, int id)
        {
            using(SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
              
                command.Connection = connection;
                command.CommandText = "UPDATE Books SET " +
                        "Name = " + "'" + b.Name + "'" + ", " +
                        "ISBN = " + "'" + b.ISBN + "'" + ", " +
                        "Genre = " + "'" + b.Genre + "'" + "WHERE Id = " + id;
                return command.ExecuteNonQuery();
                
            }
        }
    }
}
