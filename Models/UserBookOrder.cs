using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryV2.Models
{
    public class UserBookOrder
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string DateCreated { get; set; }
        public string BookGenre { get; set; }
    }
}
