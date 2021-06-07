using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seuphone.Api.Data;
using Seuphone.Api.DTO;
using Seuphone.Api.Models;

namespace Seuphone.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SeuphoneApiContext _context;

        public ProductsController(SeuphoneApiContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string productName = null, int limit = 0)
        {

            var query = from p in _context.Product where p.StockQuantity > 0 select p;


            if (productName != null)
            {
                query = query.Where(a => a.ProductName.Contains(productName) || a.Description.Contains(productName));
            }

            if (limit != 0)
            {

                return await query.Take(limit).Include(p => p.Provider).ToListAsync();
            }

            return await query.Include(p => p.Provider).ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product
                .Include(p => p.Provider)
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO product)
        {
            //if (id != product.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(product).State = EntityState.Modified;

            var findProduct = _context.Product
                   .Where(product => product.Id == id)
                   .SingleOrDefault();


            if (findProduct != null)
            {
                if (product.Image == "" || product.Image == null)
                {
                }
                else
                {
                    findProduct.Image = product.Image;
                }
                findProduct.ProductName = product.ProductName;
                findProduct.Description = product.Description;
                findProduct.Model = product.Model;
                findProduct.Color = product.Color;
                findProduct.Storage = product.Storage;
                findProduct.Price = product.Price;
                findProduct.StockQuantity = product.StockQuantity;
                findProduct.ProviderId = product.ProviderId;

                _context.Entry(findProduct).State = EntityState.Modified;

                _context.Update(findProduct);


                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        [HttpGet("admin")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {

            return await _context.Product.Include(p => p.Provider).ToListAsync();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
