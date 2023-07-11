using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Manager.Interfaces;
using Restaurant.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors()]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly LibraryDbContext context;
        private readonly JWTSettings setting;
        private readonly IUserManager _userManager;
        public UserController(IOptions<JWTSettings> options, IUserManager userManager)
        {
            setting = options.Value;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentials userCredentials)
        {
            var _user = await _userManager.GetUser(userCredentials);

            if (_user == null)
                return Unauthorized(new { message = "Invalid User Credentials" });

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(setting.SecurityKey);
            IList<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.Email),
                new Claim(ClaimTypes.Role, _user.Role)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(20),
                Issuer = setting.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var uid = Guid.NewGuid().ToString().Replace("-", "");
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);

            return Ok(new
            {
                email = _user.Email,
                code = 200,
                token=finaltoken,
                role=_user.Role,
            });
        }

    }
}
