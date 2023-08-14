using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    [ApiController]
    [Route("api/[controller]")]
    public class GardenersController : ControllerBase
    {
        private readonly GardenerService _gardenerService;

        public GardenersController(GardenerService gardenerService)
        {
            _gardenerService = gardenerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gardener>>> Get()
        {
            var gardeners = await _gardenerService.GetAllGardeners();
            return Ok(gardeners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gardener>> Get(int id)
        {
            var gardener = await _gardenerService.GetGardenerById(id);
            if (gardener == null)
            {
                return NotFound();
            }
            return Ok(gardener);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Gardener gardener)
        {
            await _gardenerService.AddGardener(gardener);
            return CreatedAtAction(nameof(Get), new { id = gardener.Id }, gardener);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Gardener gardener)
        {
            if (id != gardener.Id)
            {
                return BadRequest();
            }
            await _gardenerService.UpdateGardener(gardener);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _gardenerService.DeleteGardener(id);
            return NoContent();
        }
    }

}
