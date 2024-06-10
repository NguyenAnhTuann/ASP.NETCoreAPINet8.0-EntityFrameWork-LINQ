using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mywebapi.Data;

namespace Mywebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumesController : ControllerBase
    {
        private readonly PerfumeContext _context;

        public PerfumesController(PerfumeContext context)
        {
            _context = context;
        }

        // GET: api/Perfumes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfume>>> GetSANPHAMs()
        {
            return await _context.SANPHAMs!.ToListAsync();
        }

        // GET: api/Perfumes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfume>> GetPerfume(int id)
        {
            var perfume = await _context.SANPHAMs!.FindAsync(id);

            if (perfume == null)
            {
                return NotFound();
            }

            return perfume;
        }

        // PUT: api/Perfumes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfume(int id, Perfume perfume)
        {
            if (id != perfume.ID)
            {
                return BadRequest();
            }

            _context.Entry(perfume).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfumeExists(id))
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

        // POST: api/Perfumes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Perfume>> PostPerfume(Perfume perfume)
        {
            _context.SANPHAMs!.Add(perfume);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfume", new { id = perfume.ID }, perfume);
        }

        // DELETE: api/Perfumes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfume(int id)
        {
            var perfume = await _context.SANPHAMs!.FindAsync(id);
            if (perfume == null)
            {
                return NotFound();
            }

            _context.SANPHAMs.Remove(perfume);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerfumeExists(int id)
        {
            return _context.SANPHAMs!.Any(e => e.ID == id);
        }
    }
}
