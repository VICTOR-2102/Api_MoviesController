using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Base
    {
        public int Id { get; set; }
    }
}
//Classe "Base" foi criada para que haja um reaproveitamento de código.
//Permitindo que todas as outras entidades tenha o seu Id. Apenas Herdando a entidade BASE