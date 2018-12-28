using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperPro.Models.Movie
{
    public class Movie : DataModel
    {

        public Movie(string title, double rating, string duration, string type, string description, DateTime releaseDate, string producer)
        {
            this.Title = title;
            this.Rating = rating;
            this.Duration = duration;
            this.Type = type;
            this.Description = description;
            this.ReleaseDate = releaseDate;
            this.Producer = producer;
        }

        public string Title { get; set; }

        public double Rating { get; set; }

        public string Duration { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Producer { get; set; }
    }
}
