using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YW.HandoverMgmt.Api.DataLayer;
using YW.HandoverMgmt.Api.Model.DTO;

namespace YW.HandoverMgmt.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly YWDbContextcs _dbContext;
        //UserRes login;
        public AuthController(YWDbContextcs dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string mobileNo, string password)
        {
            var user = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.MobileNumber == mobileNo);
            if (mobileNo == null || password != "Password123")
            {
                return BadRequest();
            }
            var Token = JwtTokenCreate(user);
            return Ok(
                new
                {
                    Token = Token,
                    Message = "Login successful",
                    user
                });
        }

        private string JwtTokenCreate(UserRes user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my Secret key for authentication");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Name)
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject= identity,
                Expires= DateTime.Now.AddDays(1),
                SigningCredentials= credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
