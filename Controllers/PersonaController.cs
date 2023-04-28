using Microsoft.AspNetCore.Mvc;
using WebApiPersona.Entities;
using WebApiPersona.Repository;

namespace WebApiPersona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
           _personaRepository = personaRepository;
        }

        [HttpPost]
        [Route("GuardarPersona")]
        public async Task<IActionResult> GuardarPersona(persona modelPersona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _personaRepository.GuardarPersona(modelPersona);
                return Ok(response);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                throw;
            }
        }
    }
}
