using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class PlayMovie : Base  
    {
        //public int FilmePorEspectador { get; set; } // Ver quantos filmes cada espectador viu
        //public int EspectadorPorFilme { get; set; } // Ver quantos espectadores um filme teve
        public string NomeDoFilme { get; set; }
        public int EspectadorId { get; set; }
        public int FilmeId { get; set; }
        public virtual Espectador Espectador { get; set; }
        public virtual Filme Filme { get; set; }
    }
}


