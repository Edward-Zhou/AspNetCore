using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int AverageRating { get; set; }
    }

    public enum Classification
    {
        NewestFirst,
        OldestFirst,
        MostPopular,
        LeastPopular
    }
}
