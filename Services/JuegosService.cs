using Microsoft.EntityFrameworkCore;
using Videojuegos.Data;
using Videojuegos.Data.Models;

namespace Videojuegos.Services
{
    public class JuegosService
    {


        private readonly VideojuegosContext _context;

        public JuegosService(VideojuegosContext context) {

            _context = context;
        
        }

        public async Task<IEnumerable<Juego>> GetJuegos()
        {
            return await _context.Juegos.ToListAsync();
        }


        public async Task<Juego?> GetJuegoById(int id)
        {
            return await _context.Juegos.FindAsync(id);
        }


        public async Task<Juego> CreateJuego(Juego juego)
        {
            _context.Juegos.Add(juego);
            await _context.SaveChangesAsync();

            return juego;
        }


        public async Task UpdateJuego(int id, Juego juego)
        {
            var existingJuego = await GetJuegoById(juego.Id);

            if (existingJuego is not null) {
            
                existingJuego.Nombre= juego.Nombre;
                existingJuego.Consola = juego.Consola;

                await _context.SaveChangesAsync();
            
            }
        }


        public async Task DeleteJuego(int id)
        {

            var juegoToDelete = await GetJuegoById(id);

            if (juegoToDelete is not null)
            {
                _context.Juegos.Remove(juegoToDelete);
                await _context.SaveChangesAsync();
            }


        }



    }
}
