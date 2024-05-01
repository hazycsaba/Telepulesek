using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telepulesek.API.Data;
using Telepulesek.Models.DTOs;
using Telepulesek.Models.Entities;

namespace Telepulesek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelepulesekController : ControllerBase
    {
        private readonly TelepulesekContext _context;

        public TelepulesekController(TelepulesekContext context)
        {
            _context = context;
        }

        // GET: api/Telepulesek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDTO>>> Gettelepulesek(
            int page = 0, int itemsPerPage = 20,
            string? search = null,
            string? sortBy = null, bool ascending = true)
        {
            var query = _context.telepulesek
                .Include(telepules => telepules.megye)
                .OrderBy(telepules => telepules.megnevezes)
                .AsQueryable();

            if(!string.IsNullOrWhiteSpace(search))
            {
                int.TryParse(search, out int irsz);
                query = query.Where(telepules =>
                telepules.megnevezes.ToLower().Contains(search) ||
                telepules.telepulesresz.ToLower().Contains(search) ||
                telepules.IRSZ.Equals(irsz));
            }
            if(!string.IsNullOrWhiteSpace(sortBy))
            {

            }
            return result.ToDTO();
        }

        // GET: api/Telepulesek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TelepulesDTO>> GetTelepules(int id)
        {
            var telepules = await _context.telepulesek
                .Include(t => t.jogallas)
                .Include(t => t.hivatal_kod)
                .Include(t => t.megye)
                .Include(t => t.jaras)
                .FirstOrDefaultAsync(t => t.id == id);
            
            if (telepules == null)
            {
                return NotFound();
            }

            var hivatal = await _context.telepulesek
                .FirstOrDefaultAsync(t => t.id == telepules.hivatal_szekhely_id);

            string? hivatalSzekhely = hivatal != null? hivatal.megnevezes : null;

            var kisebbsegiOnkormanyzatok = await _context.telepules_kisebbsegi_kapcsolatok
                .Include(onk => onk.onkormanyzat)
                .Where(onk => onk.telepules_id == id)
                .Select(onk => onk.onkormanyzat.megnevezes)
                .ToListAsync();

            TelepulesDTO telepulesDTO = new TelepulesDTO
                (
                    telepules.megnevezes, 
                    telepules.IRSZ, 
                    telepules.telepulesresz, 
                    telepules.ksh_kod, 
                    telepules.jogallas.jogallas, 
                    telepules.megye.megye, 
                    telepules.jaras.jaras,
                    telepules.hivatal_kod.jelentes, 
                    hivatalSzekhely,
                    telepules.terulet, 
                    telepules.nepesseg, 
                    telepules.lakasok, 
                    kisebbsegiOnkormanyzatok
                );



            return telepulesDTO;
        }

        // PUT: api/Telepulesek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelepules(int id, Telepules telepules)
        {
            if (id != telepules.id)
            {
                return BadRequest();
            }

            _context.Entry(telepules).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelepulesExists(id))
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

        // POST: api/Telepulesek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Telepules>> PostTelepules(Telepules telepules)
        {
            _context.telepulesek.Add(telepules);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelepules", new { id = telepules.id }, telepules);
        }

        // DELETE: api/Telepulesek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelepules(int id)
        {
            var telepules = await _context.telepulesek.FindAsync(id);
            if (telepules == null)
            {
                return NotFound();
            }

            _context.telepulesek.Remove(telepules);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelepulesExists(int id)
        {
            return _context.telepulesek.Any(e => e.id == id);
        }
    }
}
