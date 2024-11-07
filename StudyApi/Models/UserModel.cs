using System.Text.Json.Serialization;

namespace StudyApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public ICollection<OpinionModel> Opinions { get; set; }

    }
}
