using System.ComponentModel.DataAnnotations;

namespace Review.Data
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ReviewText { get; set; }
    }
}
