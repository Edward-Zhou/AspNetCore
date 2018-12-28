using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperPro.Models.Movie
{
    public class MovieDto
    {
        public string Title { get; set; }

        public double Rating { get; set; }

        public string Duration { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Producer { get; set; }
    }
}
