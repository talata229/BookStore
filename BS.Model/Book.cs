using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
        public bool IsNew { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
    }
}
