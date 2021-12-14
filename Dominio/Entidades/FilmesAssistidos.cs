using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class FilmesAssistidos : Base
    {
        public int IdEspectador { get; set; }
        public int IdFilme { get; set; }
    }
}
