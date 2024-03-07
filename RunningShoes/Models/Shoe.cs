using System;
using System.ComponentModel.DataAnnotations;

namespace RunningShoes.Models
{
    public class Shoe
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Name { get; set; }

        public string Type { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
