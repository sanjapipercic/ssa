using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BookBusiness : IBookBusiness
    {
        private IBookRepository bookRepository;
        public BookBusiness(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public List<Book> GetBooks()
        {
            List<Book> books = this.bookRepository.GetBooks();
            if(books.Count > 0)
            {
                return books;
            }
            else
            {
                return null;
            }
        }
        public Book GetBookByISBN(string ISBN)
        {
            List<Book> books = this.bookRepository.GetBooks();
            return books.Find(b => b.ISBN == ISBN);
        }

        public bool Insert(Book book)
        {
            if(this.bookRepository.Insert(book) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(UpdateBookDTO b, int id)
        {
            if(id != 0 && this.bookRepository.Update(b, id) > 0)
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
