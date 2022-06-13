using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryManagement.Models;

namespace GroceryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciepreturnedsController : ControllerBase
    {
        private readonly MarketManagementDBContext _context;

        public ReciepreturnedsController(MarketManagementDBContext context)
        {
            _context = context;
        }

        // GET: api/Reciepreturneds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reciepreturned>>> GetReciepreturneds()
        {
          if (_context.Reciepreturneds == null)
          {
              return NotFound();
          }
            return await _context.Reciepreturneds.ToListAsync();
        }

        // GET: api/Reciepreturneds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reciepreturned>> GetReciepreturned(int id)
        {
          if (_context.Reciepreturneds == null)
          {
              return NotFound();
          }
            var reciepreturned = await _context.Reciepreturneds.FindAsync(id);

            if (reciepreturned == null)
            {
                return NotFound();
            }

            return reciepreturned;
        }

        // PUT: api/Reciepreturneds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReciepreturned(int id, Reciepreturned reciepreturned)
        {
            if (id != reciepreturned.ReciepId)
            {
                return BadRequest();
            }

            _context.Entry(reciepreturned).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciepreturnedExists(id))
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

        // POST: api/Reciepreturneds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reciepreturned>> PostReciepreturned(Reciepreturned reciepreturned)
        {
          if (_context.Reciepreturneds == null)
          {
              return Problem("Entity set 'MarketManagementDBContext.Reciepreturneds'  is null.");
          }
            _context.Reciepreturneds.Add(reciepreturned);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReciepreturned", new { id = reciepreturned.ReciepId }, reciepreturned);
        }

        // DELETE: api/Reciepreturneds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReciepreturned(int id)
        {
            if (_context.Reciepreturneds == null)
            {
                return NotFound();
            }
            var reciepreturned = await _context.Reciepreturneds.FindAsync(id);
            if (reciepreturned == null)
            {
                return NotFound();
            }

            _context.Reciepreturneds.Remove(reciepreturned);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReciepreturnedExists(int id)
        {
            return (_context.Reciepreturneds?.Any(e => e.ReciepId == id)).GetValueOrDefault();
        }
    }
}
