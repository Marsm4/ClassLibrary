using Clinical_Hospital_33.Models;
using Clinical_Hospital_33.Services;
using Microsoft.AspNetCore.Mvc;
using IVrachService = Clinical_Hospital_33.Models.IVrachService;


namespace Clinical_Hospital_33.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VrachController : ControllerBase
    {
        private readonly IVrachService _vrachService;

        public VrachController(IVrachService vrachService)
        {
            _vrachService = vrachService;
        }

        // GET: api/Vrach
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vrach>>> GetVrachList()
        {
            return Ok(await _vrachService.GetAllVrach());
        }

        // GET: api/Vrach/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vrach>> GetVrach(int id)
        {
            var vrach = await _vrachService.GetVrachById(id);
            if (vrach == null)
            {
                return NotFound();
            }
            return Ok(vrach);
        }

        // POST: api/Vrach
        [HttpPost]
        public async Task<ActionResult<Vrach>> CreateVrach(Vrach vrach)
        {
            await _vrachService.AddVrach(vrach);
            return CreatedAtAction(nameof(GetVrach), new { id = vrach.Id_vracha }, vrach);
        }

        // PUT: api/Vrach/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVrach(int id, Vrach vrach)
        {
            if (id != vrach.Id_vracha)
            {
                return BadRequest();
            }

            await _vrachService.UpdateVrach(vrach);
            return NoContent();
        }

        // DELETE: api/Vrach/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVrach(int id)
        {
            await _vrachService.DeleteVrach(id);
            return NoContent();
        }
    }
}