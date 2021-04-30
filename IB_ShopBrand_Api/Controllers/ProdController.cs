using IB_ShopBrand_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IB_ShopBrand_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdController : ControllerBase
    {
        private readonly IB_IBS_PortalContext _context;
        public ProdController(IB_IBS_PortalContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            try
            {
                
                await _context.SaveChangesAsync();               
            }
            catch (DbUpdateException)
            {
                    return BadRequest();
              
            }
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }
    }
}
