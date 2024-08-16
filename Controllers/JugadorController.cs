using Microsoft.AspNetCore.Mvc;
using AtleticoNacionalCRUD.Models;
using AtleticoNacionalCRUD.Data;
using Microsoft.EntityFrameworkCore;


namespace AtleticoNacionalCRUD.Controllers
{
    public class JugadorController : Controller
    {
        private readonly AppDBContext _appContext;
        public JugadorController(AppDBContext appContext)
        {
            _appContext = appContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Jugador> lista = await _appContext.Jugadores.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            var jugador = new Jugador(); // Crear una instancia de Jugador
            return View(jugador); // Pasar la instancia a la vista
        }


        [HttpPost]
        public async Task<IActionResult> Nuevo(Jugador jugador)
        {
            await _appContext.Jugadores.AddAsync(jugador);
            await _appContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Jugador jugador = await _appContext.Jugadores.FirstAsync(j => j.Id == id);
            return View(jugador);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Jugador jugador)
        {
            _appContext.Jugadores.Update(jugador);
            await _appContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Jugador jugador = await _appContext.Jugadores.FirstAsync(j => j.Id == id);
            _appContext.Jugadores.Remove(jugador);
            await _appContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

    }
}