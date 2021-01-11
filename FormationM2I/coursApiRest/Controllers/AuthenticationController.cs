using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace coursApiRest.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _config;
        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("login")]
        public JsonResult Login(string username, string password)
        {
            bool isLogged = false;
            if(isLogged)
            {
                return new JsonResult(new { token = GenerateJWT("abadi", "ihab ") });
            }
            else
            {
            return new JsonResult(new { error = true});

            }
        }

        private string GenerateJWT(string nom, string prenom)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("jwt:key")));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, nom + " "+prenom)
            };
            JwtSecurityToken token = new JwtSecurityToken(_config.GetValue<string>("jwt:issuer"), _config.GetValue<string>("jwt:audience"), claims, expires : DateTime.Now.AddDays(1), signingCredentials: credentials);
            string stringToken = new JwtSecurityTokenHandler().WriteToken(token);
            return stringToken;
        }
    }
}