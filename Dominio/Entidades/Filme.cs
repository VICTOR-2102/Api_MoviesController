using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Filme : Base
    {
        public string Nome { get; set; }
        public int AnoLancamento { get; set; }
        public string Genero { get; set; }
        public string FaixaEtaria { get; set; }
        public int Duracao { get; set; }
        public string Sinopse { get; set; }

        [JsonIgnore]
        public virtual ICollection<Espectador> Espectadores { get; set; }
    }
}
