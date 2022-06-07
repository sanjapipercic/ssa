using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBookRepository
    {
        int Insert(Book book);

        List<Book> GetBooks();
        int Update(UpdateBookDTO b,int id);
    }
}
