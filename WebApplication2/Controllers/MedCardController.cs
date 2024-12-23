using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalHospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedCardController : ControllerBase
    {
        private readonly ClinicalHospitalDbContext _context;

        public MedCardController(ClinicalHospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/MedCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedCard>>> GetAllMedCards()
        {
            return await _context.MedCards.ToListAsync();
        }

        // GET: api/MedCard/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MedCard>> GetMedCardById(int id)
        {
            var medCard = await _context.MedCards.FindAsync(id);

            if (medCard == null)
            {
                return NotFound();
            }

            return medCard;
        }

        // POST: api/MedCard
        [HttpPost]
        public async Task<ActionResult<MedCard>> CreateMedCard(MedCard medCard)
        {
            _context.MedCards.Add(medCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMedCardById), new { id = medCard.Id }, medCard);
        }

        // PUT: api/MedCard/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedCard(int id, MedCard medCard)
        {
            if (id != medCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(medCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedCardExists(id))
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

        // DELETE: api/MedCard/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedCard(int id)
        {
            var medCard = await _context.MedCards.FindAsync(id);
            if (medCard == null)
            {
                return NotFound();
            }

            _context.MedCards.Remove(medCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedCardExists(int id)
        {
            return _context.MedCards.Any(e => e.Id == id);
        }
    }

    // Example DbContext and MedCard model
    public class ClinicalHospitalDbContext : DbContext
    {
        public ClinicalHospitalDbContext(DbContextOptions<ClinicalHospitalDbContext> options) : base(options) { }

        public DbSet<MedCard> MedCards { get; set; }
    }

    public class MedCard
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public int DoctorId { get; set; }
    }
}
