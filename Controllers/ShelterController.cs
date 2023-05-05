using AnimalShelter.Service.AnimalService;
using AnimalShelter.Service.ShelterService;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelterController : ControllerBase
    {

        private readonly ShelterService _shelterService;

        public ShelterController(IShelterService shelterService)
        {
            _shelterService = (ShelterService?)shelterService;
        }

        [HttpGet("get-shelters")]
        public async Task<ActionResult<List<Shelter>>> GetAllShelters()
        {
            var result = await _shelterService.GetAllShelters();
            return Ok(result);
        }

        [HttpGet("get-shelter/{shelterId}")]
        public async Task<ActionResult<Shelter>> GetShelterById([FromRoute] int shelterId)
        {
            try
            {
                var result = await _shelterService.GetShelterById(shelterId);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid");
            }
        }


        [HttpPost("add-shelter")]
        public async Task<ActionResult<Shelter>> AddShelter([FromBody] Shelter shelter)
        {
            try
            {
                await _shelterService.AddShelter(shelter);
                return Ok(shelter);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid");
            }
        }


        [HttpPut("update-shelter")]
        public async Task<ActionResult<Shelter>> UpdateShelter([FromBody] Shelter shelter)
        {
            try
            {
                var result = await _shelterService.UpdateShelter(shelter);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid");
            }
        }


        [HttpDelete("delete-shelter/{shelterId}")]
        public async Task<IActionResult> DeleteAnimal([FromRoute] int shelterId)
        {
            try
            {
                await _shelterService.DeleteShelter(shelterId);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid");
            }
        }
    }
}
