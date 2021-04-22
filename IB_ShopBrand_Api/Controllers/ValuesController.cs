using IB_ShopBrand_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IBShop_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IB_IBS_PortalContext _context;
        private readonly JWTSettings _jwtsettings;

        public ValuesController(IB_IBS_PortalContext context, IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<IbsUser>> Login([FromBody] IbsUser user)
        {

            {
                var ibUser = await _context.IbsUsers.FirstOrDefaultAsync(x => x.UserEmail == user.UserEmail && x.UserPassword == user.UserPassword);

                if (ibUser == null)
                {
                    return NotFound();
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserEmail)
                    }),
                    Expires = DateTime.UtcNow.AddMonths(6),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                ibUser.Token = tokenHandler.WriteToken(token);
                return ibUser;
            }

        }
    }
}
