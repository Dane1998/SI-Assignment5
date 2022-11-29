namespace Review.Data
{
    public class Reviews
    {
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ReviewText { get; set; }
    }
}
