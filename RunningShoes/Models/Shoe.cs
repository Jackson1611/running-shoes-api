using System;
using System.ComponentModel.DataAnnotations;

namespace RunningShoes.Models
{
    public class Shoe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Type { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Release year is required")]
        public DateTime ReleaseYear { get; set; }
    }
}
