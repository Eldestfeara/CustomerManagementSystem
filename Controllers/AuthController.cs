using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomerManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        string signinKey = "SigningKeyForCustomerManagement";
        [HttpGet]
        public string Get(string userName, string password, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.Role,role)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "alperenoncel",
                audience: "AtananAudienceDegeri",
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                notBefore: DateTime.Now,
                signingCredentials: credentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }
        [HttpGet("ValidateToken")]
        public bool ValidateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidAudience = "AtananAudienceDegeri",
                    ValidateIssuer = true,
                    ValidIssuer = "alperenoncel"
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
