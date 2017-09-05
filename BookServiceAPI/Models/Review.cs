using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServiceAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Reviewer { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }
    }
}
