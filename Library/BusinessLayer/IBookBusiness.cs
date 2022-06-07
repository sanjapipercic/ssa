using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBookBusiness
    {
        public bool Insert(Book book);
        public bool Update(UpdateBookDTO b, int id);
        public Book GetBookByISBN(string ISBN);
        public List<Book> GetBooks();
    }
}
