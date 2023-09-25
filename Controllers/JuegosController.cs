using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using Videojuegos.Data;
using Videojuegos.Data.Models;

namespace Videojuegos.Controllers
{

    [ApiController]
    [Route("juegos")]
    public class JuegosController : ControllerBase
    {

        private readonly VideojuegosContext _context;

        public JuegosController(VideojuegosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Juego> GetJuegos()
        {
            return _context.Juegos.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Juego> GetJuegoById(int id)
        {

            var juego = _context.Juegos.Find(id);

            if (juego is null)
            {
                return NotFound();
            }

            return juego;
        }

        [HttpPost("add")]
        public IActionResult CreateJuego(Juego juego)
        {

            _context.Juegos.Add(juego);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetJuegoById), new {id = juego.Id }, juego);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateJuego(int id, Juego juego)
        {

            if (id != juego.Id)
            {
                return BadRequest();
            }

            var existingJuego = _context.Juegos.Find(id);
            if (existingJuego is null)
            {
                return NotFound();
            }

            existingJuego.Nombre = juego.Nombre;
            existingJuego.Consola = juego.Consola;

            _context.SaveChanges();

            return NoContent(); 


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJuego(int id)
        {

            var existingJuego = _context.Juegos.Find(id);
            if (existingJuego is null)
            {
                return NotFound();
            }

            _context.Juegos.Remove(existingJuego);
            _context.SaveChanges();

            return Ok();

        }



    }
}
