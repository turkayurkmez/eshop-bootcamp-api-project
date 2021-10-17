using eshop.API.Models;
using eshop.Services;
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

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("Login")]
        public IActionResult Login(UserLogin userLogin)
        {
            var user = new UserService().IsValid(userLogin.UserName, userLogin.Password);
            if (user == null)
            {
                return BadRequest("Kullanıcı adı ya da şifre....");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var issuer = "turkayurkmez.com";
            var audience = "turkayurkmez.com";
            var key = "bugun-gunlerden-pazar-ve-guzel-bir-gun";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(issuer: issuer,
                                             audience: audience,
                                             claims: claims,
                                             notBefore: DateTime.Now,
                                             expires: DateTime.Now.AddMinutes(20),
                                             signingCredentials: credential
                                             );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                
        }
    }
}
