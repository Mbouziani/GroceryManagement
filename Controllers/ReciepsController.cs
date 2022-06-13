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
    public class ReciepsController : ControllerBase
    {
        private readonly MarketManagementDBContext _context;

        public ReciepsController(MarketManagementDBContext context)
        {
            _context = context;
        }

        // GET: api/Recieps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reciep>>> GetRecieps()
        {
          if (_context.Recieps == null)
          {
              return NotFound();
          }
            return await _context.Recieps.ToListAsync();
        }
        // GET: api/Recieps/545545
        [HttpGet("one")]
        public async Task<ActionResult< Reciep >> GetReciepsbyNumber(int number,int count)
        {
            if (_context.Recieps == null)
            {
                return NotFound();
            }
            var reciep = await _context.Recieps.Where(r=>r.ReciepNumber == number && r.ReciepProductCount == count). ToListAsync();
            return reciep.First();
        }

        // GET: api/Recieps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reciep>> GetReciep(int id)
        {
          if (_context.Recieps == null)
          {
              return NotFound();
          }
            var reciep = await _context.Recieps.FindAsync(id);

            if (reciep == null)
            {
                return NotFound();
            }

            return reciep;
        }

        // PUT: api/Recieps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReciep(int id, Reciep reciep)
        {
            if (id != reciep.ReciepId)
            {
                return BadRequest();
            }

            _context.Entry(reciep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciepExists(id))
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

        // POST: api/Recieps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reciep>> PostReciep(Reciep reciep)
        {
          if (_context.Recieps == null)
          {
              return Problem("Entity set 'MarketManagementDBContext.Recieps'  is null.");
          }
            _context.Recieps.Add(reciep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReciep", new { id = reciep.ReciepId }, reciep);
        }

        // DELETE: api/Recieps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReciep(int id)
        {
            if (_context.Recieps == null)
            {
                return NotFound();
            }
            var reciep = await _context.Recieps.FindAsync(id);
            if (reciep == null)
            {
                return NotFound();
            }

            _context.Recieps.Remove(reciep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReciepExists(int id)
        {
            return (_context.Recieps?.Any(e => e.ReciepId == id)).GetValueOrDefault();
        }
    }
}
