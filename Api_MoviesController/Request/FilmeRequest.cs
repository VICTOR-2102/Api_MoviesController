namespace Api_MoviesController.Request
{
    public class FilmeRequest
    {
        public string Nome { get; set; }
        public int AnoLancamento { get; set; }
        public string Genero { get; set; }
        public string FaixaEtaria { get; set; }
        public int Duracao { get; set; }
        public string Sinopse { get; set; }
    }
}
