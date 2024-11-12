using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudyApi.Account;
using StudyApi.Data;
using StudyApi.Models;
using StudyApi.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudyApi.Services.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly JwtSettings _jwtSettings;
        private readonly AppDbContext _context;

        public AuthenticateService(AppDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }

            if (user.Password != password)
            {
                return false;
            }

            return true;
        }

        public string GenerateToken(int id, string username)
        {

            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("username", username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_jwtSettings.ExpirationDays),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserModel> GetUserByUsername(string username)
        {
            return await _context.Users.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<bool> UserExists(string username)
        {
            var user = await _context.Users.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
