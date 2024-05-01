using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telepulesek.API.Data;
using Telepulesek.Models.DTOs;
using Telepulesek.Models.Entities;

namespace Telepulesek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeresesController : ControllerBase
    {
        private readonly TelepulesekContext _context;

        public KeresesController(TelepulesekContext context)
        {
            _context = context;
        }

        [HttpGet("{keres}")]
        public async Task<ActionResult<List<TelepulesDTO>>> Kereses(string keres)
        {
            List<Telepules>? telepulesek = new List<Telepules>();
            if(int.TryParse(keres, out int irsz))
            {
                telepulesek = await _context.telepulesek
                    .Include(t => t.jogallas)
                    .Include(t => t.hivatal_kod)
                    .Include(t => t.megye)
                    .Include(t => t.jaras)
                    .Where(t => t.IRSZ == irsz).ToListAsync();
            }
            else
            {
                telepulesek = await _context.telepulesek
                    .Include(t => t.jogallas)
                    .Include(t => t.hivatal_kod)
                    .Include(t => t.megye)
                    .Include(t => t.jaras)
                    .Where(t => t.megnevezes.Contains(keres) || t.telepulesresz.Contains(keres)).ToListAsync();
            }

            if(telepulesek == null)
            {
                return NotFound("Nincs ilyen település!");
            }
            List<TelepulesDTO> telepulesDTOs = new List<TelepulesDTO>();
            foreach (Telepules telepules in telepulesek)
            {
                var hivatal = await _context.telepulesek
                    .FirstOrDefaultAsync(t => t.id == telepules.hivatal_szekhely_id);

                string? hivatalSzekhely = hivatal != null ? hivatal.megnevezes : null;

                var kisebbsegiOnkormanyzatok = await _context.telepules_kisebbsegi_kapcsolatok
                    .Include(onk => onk.onkormanyzat)
                    .Where(onk => onk.telepules_id == telepules.id)
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
                telepulesDTOs.Add(telepulesDTO);
            }


            return telepulesDTOs;
        }
    }
}
