namespace RunningShoes.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Reviewer { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
