using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReproductorMusical.Models;
using ReproductorMusical.ViewModels;

namespace ReproductorMusical.Controllers
{
    public class CancionesController : Controller
    {
        public readonly ApplicationDbContext _contexto;
        public CancionesController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //List<Cancion> ListaCanciones = _contexto.Cancion.ToList();
            //return View(ListaCanciones);

            List<Cancion> ListaCanciones = _contexto.Cancion.Include(x => x.Playlist).ToList();
            return View(ListaCanciones);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            CancionPlaylistVM cancionPlaylistVM = new CancionPlaylistVM();
            cancionPlaylistVM.ListaPlaylist = _contexto.Playlist.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Playlist_Id.ToString()
            });
            return View(cancionPlaylistVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                _contexto.Cancion.Add(cancion);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            //Para que al retornar la vista por algun error, también retorne la lista de playlist
            CancionPlaylistVM cancionPlaylistVM = new CancionPlaylistVM();
            cancionPlaylistVM.ListaPlaylist = _contexto.Playlist.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.Playlist_Id.ToString()
            });

            return View(cancionPlaylistVM);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id==null)
            {
                return View();
            }
            CancionPlaylistVM cancionPlaylistVM = new CancionPlaylistVM();
            cancionPlaylistVM.ListaPlaylist = _contexto.Playlist.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Playlist_Id.ToString()
            });

            cancionPlaylistVM.Cancion = _contexto.Cancion.FirstOrDefault(x => x.Cancion_Id == id);
            if (cancionPlaylistVM == null)
            {
                return NotFound();
            }
            return View(cancionPlaylistVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                _contexto.Cancion.Update(cancion);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cancion);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var borrar = _contexto.Cancion.FirstOrDefault(x => x.Cancion_Id == id);
            _contexto.Cancion.Remove(borrar);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
