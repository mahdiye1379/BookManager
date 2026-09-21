using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Client.Data
{
    public  class Author
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public string? Image { get; internal set; }
        public List<Book> Books { get; set; }
    }
}
