using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensitivewordsAPI;
using SensitivewordsAPI.Models;

namespace SensitivewordsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensitiveWordItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SensitiveWordItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SensitiveWordItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensitiveWordItem>>> GetSensitiveWords()
        {
          if (_context.SensitiveWords == null)
          {
              return NotFound();
          }
            return await _context.SensitiveWords.ToListAsync();
        }

        // GET: api/SensitiveWordItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensitiveWordItem>> GetSensitiveWordItem(int id)
        {
          if (_context.SensitiveWords == null)
          {
              return NotFound();
          }
            var sensitiveWordItem = await _context.SensitiveWords.FindAsync(id);

            if (sensitiveWordItem == null)
            {
                return NotFound();
            }

            return sensitiveWordItem;
        }

        // PUT: api/SensitiveWordItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensitiveWordItem(int id, SensitiveWordItem sensitiveWordItem)
        {
            if (id != sensitiveWordItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensitiveWordItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensitiveWordItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SensitiveWordItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SensitiveWordItem>> PostSensitiveWordItem(SensitiveWordItem sensitiveWordItem)
        {
          if (_context.SensitiveWords == null)
          {
              return Problem("Entity set 'ApplicationDbContext.SensitiveWords'  is null.");
          }
            _context.SensitiveWords.Add(sensitiveWordItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensitiveWordItem", new { id = sensitiveWordItem.Id }, sensitiveWordItem);
        }

        // DELETE: api/SensitiveWordItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensitiveWordItem(int id)
        {
            if (_context.SensitiveWords == null)
            {
                return NotFound();
            }
            var sensitiveWordItem = await _context.SensitiveWords.FindAsync(id);
            if (sensitiveWordItem == null)
            {
                return NotFound();
            }

            _context.SensitiveWords.Remove(sensitiveWordItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SensitiveWordItemExists(int id)
        {
            return (_context.SensitiveWords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
