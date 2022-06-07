using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookBusiness bookBusiness;

        public BookController(IBookBusiness bookBusiness)
        {
            this.bookBusiness = bookBusiness;
        }

        [HttpGet("getall")]
        public List<Book> GetBooks()
        {
            return this.bookBusiness.GetBooks(); 
        }

        [HttpGet("getall/{ISBN}")]
        public Book GetBookByISBN(string ISBN)
        {
            return this.bookBusiness.GetBookByISBN(ISBN);
        }

        [HttpPut("update/{id}")]
        public bool Update([FromBody] UpdateBookDTO book, int id)
        {
            return this.bookBusiness.Update(book, id);
        }

        [HttpPost("insert")]
        public bool Insert([FromBody] Book book)
        {
            return this.bookBusiness.Insert(book);
        }
    }
}
