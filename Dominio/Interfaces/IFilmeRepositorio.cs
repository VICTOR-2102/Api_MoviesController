﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IFilmeRepositorio : IBaseRepositorio<Filme>
    { }//IFilmeRepositorio herda(:) de IBaseRepositorio adquirindo todos seus atributos/properties e métodos,
       //assim favorecendo o reaproveitamento de código e o polimorfismo.
}
