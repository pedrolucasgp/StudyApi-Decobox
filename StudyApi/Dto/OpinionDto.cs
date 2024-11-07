using StudyApi.Models;

namespace StudyApi.Dto
{
    public class OpinionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Feedback { get; set; }
        public decimal Rating { get; set; }
        public UserMatchDto User { get; set; }
    }
}
