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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly IB_IBS_PortalContext _context;
        //private readonly JWTSettings _jwtsettings;

        public CatController(IB_IBS_PortalContext context/*, IOptions<JWTSettings> jwtsettings*/)
        {
            _context = context;
            //_jwtsettings = jwtsettings.Value;
        }


        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            try
            {
                await _context.SaveChangesAsync();
                if (CategoryExists(category.CategoryTitle))
                {
                    return NotFound();
                }


                //var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
                //var tokenDescriptor = new SecurityTokenDescriptor
                //{
                //    Subject = new ClaimsIdentity(new Claim[]
                //    {
                //        new Claim(ClaimTypes.Name, category.CategoryTitle)
                //    }),
                //    Expires = DateTime.UtcNow.AddMonths(6),
                //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                //    SecurityAlgorithms.HmacSha256Signature)
                //};
                //var token = tokenHandler.CreateToken(tokenDescriptor);
                //category.Token = tokenHandler.WriteToken(token);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            return CreatedAtAction("Getcategory", new { id = category.CategoryTitle }, category);
        }

        private bool CategoryExists(string categoryTitle)
        {
            throw new NotImplementedException();
        }
    }
}

