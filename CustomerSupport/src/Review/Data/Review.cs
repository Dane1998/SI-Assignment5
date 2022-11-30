using System.ComponentModel.DataAnnotations;

namespace Review.Data
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ReviewText { get; set; }
        public int Rating { get; set; }

    }
}
