using BS.Model;
using BS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BS.Presentation.Models
{
    public class Cart
    {

        private readonly IBookService _bookService = new BookService();
       public int BookId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount
        {
            get
            {
                return Price * Quantity;
            }
        }

        public Cart(int bookId)
        {
            this.BookId = bookId;
            Book book = _bookService.Get(bookId);
            this.Title = book.Title;
            this.ImageUrl = book.Image;
            this.Price = book.Price;
            this.Quantity = 1;
        }
    }
}