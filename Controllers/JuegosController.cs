using Microsoft.AspNetCore.Mvc;
using Videojuegos.Data.Models;
using Videojuegos.Services;

namespace Videojuegos.Controllers
{

    [ApiController]
    [Route("juegos")]
    public class JuegosController : ControllerBase
    {

        public readonly JuegosService _service;

        public JuegosController(JuegosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Juego>> GetJuegos()
        {
            return await _service.GetJuegos();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Juego>> GetJuegoById(int id)
        {

            var juego = await _service.GetJuegoById(id);

            if (juego is null)
            {
                return JuegoNotFound(id);
            }

            return juego;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateJuego(Juego juego)
        {

            var newJuego = await _service.CreateJuego(juego);

            return CreatedAtAction(nameof(GetJuegoById), new {id = newJuego.Id }, newJuego);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJuego(int id, Juego juego)
        {

            if (id != juego.Id)
            {
                return BadRequest(new { message = $"El id ({id}) de la URL no coincide con el id ({juego.Id}) del body de la solicitud"});
            }

            var juegoToUpdate = await _service.GetJuegoById(id);

            if (juegoToUpdate is not null) {
            
                await _service.UpdateJuego(id, juego);
                return NoContent();

            }
            else
            {
                return JuegoNotFound(id);
            }



        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJuego(int id)
        {

           
            var juegoToDelete = await _service.GetJuegoById(id);

            if (juegoToDelete is not null)
            {

                await _service.DeleteJuego(id);
                return Ok();

            }
            else
            {
                return JuegoNotFound(id);
            }

        }



        //metodo para informar de juegos notFoud 404
        public NotFoundObjectResult JuegoNotFound(int id)
        {

            return NotFound(new { message = $"El juego con Id = {id} no existe" });

        }



    }
}
