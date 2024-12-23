using Microsoft.AspNetCore.Mvc;
using ClassLibrary;
using System.Collections.Generic;

namespace ClinicalHospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VrachController : ControllerBase
    {
        private readonly IVrachService _vrachService;

        public VrachController(IVrachService vrachService)
        {
            _vrachService = vrachService;
        }

        // Получить всех врачей
        [HttpGet]
        public IActionResult GetAll()
        {
            var vrachs = _vrachService.GetAll();
            return Ok(vrachs);
        }

        // Получить врача по ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var vrach = _vrachService.GetById(id);
            if (vrach == null)
            {
                return NotFound("Врач не найден.");
            }
            return Ok(vrach);
        }

        // Добавить нового врача
        [HttpPost]
        public IActionResult Add([FromBody] Vrach vrach)
        {
            if (vrach == null)
            {
                return BadRequest("Данные о враче некорректны.");
            }

            _vrachService.Add(vrach);
            return CreatedAtAction(nameof(GetById), new { id = vrach.Id_vracha }, vrach);
        }

        // Обновить данные врача
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Vrach vrach)
        {
            if (vrach == null || vrach.Id_vracha != id)
            {
                return BadRequest("Данные о враче некорректны.");
            }

            var existingVrach = _vrachService.GetById(id);
            if (existingVrach == null)
            {
                return NotFound("Врач не найден.");
            }

            _vrachService.Update(vrach);
            return NoContent(); // 204 No Content
        }

        // Удалить врача
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var vrach = _vrachService.GetById(id);
            if (vrach == null)
            {
                return NotFound("Врач не найден.");
            }

            _vrachService.Delete(id);
            return NoContent(); // 204 No Content
        }
    }
}
