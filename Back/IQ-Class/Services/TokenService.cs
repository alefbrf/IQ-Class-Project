using IQ_Class.Data.Dtos;
using IQ_Class.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IQ_Class.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(List<Claim> claims)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateAuthenticationToken(AuthenticatedUserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim("email", user.email),
                new Claim("id", user.id.ToString()),
            };

            if(user.roles != null)
            {
                foreach(string role in user.roles) 
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    };
            }

            return GenerateToken(claims);
        }

        public string GenerateResetPasswordToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("email", user.email),
                new Claim("id", user.id.ToString()),
                new Claim("verification_code", user.verification_code),
            };

            return GenerateToken(claims);
        }

        public Dictionary<string, string> DecodeToken(string token)
        {
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var claims = jwtSecurityToken.Claims.ToList();

            var TokenInfo = new Dictionary<string, string>();

            foreach (var claim in claims)
            {
                TokenInfo.Add(claim.Type, claim.Value);
            }

            return TokenInfo;
        }
    }
}
