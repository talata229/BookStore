using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Model
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
