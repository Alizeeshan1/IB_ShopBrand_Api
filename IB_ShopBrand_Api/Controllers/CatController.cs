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
 
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly IB_IBS_PortalContext _context;
    
        public CatController(IB_IBS_PortalContext context)
        {
            _context = context;
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
                    return Conflict();
                }
            }
            catch (DbUpdateException)
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

