using Microsoft.AspNetCore.Mvc;
using ReproductorMusical.Models;

namespace ReproductorMusical.Controllers
{
    public class PlaylistController : Controller
    {
        public readonly ApplicationDbContext _contexto;
        public PlaylistController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Playlist> ListaDeReproduccion = _contexto.Playlist.ToList();
            return View(ListaDeReproduccion);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _contexto.Playlist.Add(playlist);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id==null)
            {
                return View();
            }
            var editar = _contexto.Playlist.FirstOrDefault(x => x.Playlist_Id == id);
            return View(editar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Playlist play)
        {
            if (ModelState.IsValid)
            {
                _contexto.Playlist.Update(play);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(play);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var borrar = _contexto.Playlist.FirstOrDefault(x => x.Playlist_Id == id);
            _contexto.Playlist.Remove(borrar);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
