namespace Api_MoviesController.Request
{
    public class PlayMovieRequest
    {
        public string NomeDoFilme { get; set; }
        public int EspectadorId{ get; set; }
        public int FilmeId { get; set; }
        public string NomeDoEspectador { get; set; }
    }
}
