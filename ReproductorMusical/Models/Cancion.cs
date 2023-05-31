namespace ReproductorMusical.Models
{
    public class Cancion
    {
        public int Cancion_Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Productor { get; set; }
        public int Anio { get; set; }

        public int Playlist_Id { get; set; }
        public Playlist Playlist { get; set; }
    }
}