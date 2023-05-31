using Microsoft.AspNetCore.Mvc.Rendering;
using ReproductorMusical.Models;

namespace ReproductorMusical.ViewModels
{
    public class CancionPlaylistVM
    {
        public Cancion Cancion { get; set; }
        public IEnumerable<SelectListItem> ListaPlaylist { get; set; }

    }
}
