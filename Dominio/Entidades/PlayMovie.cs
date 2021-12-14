using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class PlayMovie : Base  
    {
        public int EspectadorId { get; set; }
        public int FilmeId { get; set; }
        public virtual Espectador Espectador { get; set; }
        public virtual Filme Filme { get; set; }
    }
}


