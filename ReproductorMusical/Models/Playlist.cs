namespace ReproductorMusical.Models
{
    public class Playlist
    {
        public int Playlist_Id { get; set; }
        public string Nombre { get; set; }

        public List<Cancion> Cancion { get; set; }
    }
}
