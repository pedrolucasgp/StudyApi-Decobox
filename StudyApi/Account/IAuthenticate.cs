using StudyApi.Models;

namespace StudyApi.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string userame, string password);
        Task<bool> UserExists(string username);
        public string GenerateToken(int id, string username);
        public Task<UserModel> GetUserByUsername(string username);
    }
}
