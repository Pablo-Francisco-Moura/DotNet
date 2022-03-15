using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace projeto_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticatorController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetToken()
        {
            var token = GenerateToken();
            var retorno = new
            {
                Token = token
            };

            return Ok(retorno);
        }

        private string GenerateToken()
        {
            IList<Claim> Claims = new List<Claim>();
            Claims.Add(new Claim(ClaimTypes.Role, "Adimin"));
            var handler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("lkgshdfaslksjfildshd8234klfdsjas123")), SecurityAlgorithms.HmacSha256Signature),
                Audience = "https://localhost:5001",
                Issuer = "DotNet",
                Subject = new ClaimsIdentity(Claims),
            };
            SecurityToken token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
