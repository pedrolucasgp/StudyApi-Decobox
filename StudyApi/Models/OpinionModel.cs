namespace StudyApi.Models
{
    public class OpinionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Feedback { get; set; }
        public decimal Rating { get; set; }
        public UserModel User { get; set; }
    }
}
