using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningShoes.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int ShoeId { get; set; }  // Foreign key for the shoe the review belongs to

        [Range(1, 5)]
        public int? Rating { get; set; }  // Rating from 1 to 5

        public string Content { get; set; }  // Review content

        public string ReviewerName { get; set; }  // Name of the reviewer

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;  // Date and time when the review was created
    }
}
