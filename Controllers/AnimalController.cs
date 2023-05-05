using AnimalShelter.Service.AnimalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        private readonly AnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = (AnimalService?)animalService;
        }

        [HttpGet("get-animals")]
        public async Task<ActionResult<List<Animal>>> GetAllAniamls()
        {
            var result = await _animalService.GetAllAnimals();
            return Ok(result);
        }

        [HttpGet("get-animal/{animalId}")]
        public async Task<ActionResult<Animal>> GetAnimalById([FromRoute] int animalId)
        {
            try
            {
                var result = await _animalService.GetAnimalById(animalId);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid");
            }
        }


        [HttpPost("add-animal")]
        public async Task<ActionResult<Animal>> AddAnimal([FromBody] Animal animal)
        {
            try
            {
                await _animalService.AddAnimal(animal);
                return Ok(animal);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid");
            }
        }


        [HttpPut("update-animal")]
        public async Task<ActionResult<Animal>> UpdateAnimal([FromBody] Animal animal)
        {
            try
            {
                var result = await _animalService.UpdateAnimal(animal);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid");
            }
        }


        [HttpDelete("delete-animal/{animalId}")]
        public async Task<IActionResult> DeleteAnimal([FromRoute] int animalId)
        {
            try
            {
                await _animalService.DeleteAnimal(animalId);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid");
            }
        }
    }
}
