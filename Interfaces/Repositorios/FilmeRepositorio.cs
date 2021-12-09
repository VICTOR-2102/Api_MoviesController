using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class FilmeRepositorio : BaseRepositorio<Filme> , IFilmeRepositorio
    {
        public FilmeRepositorio(BancoContexto bancoContexto) : base(bancoContexto) { }
    }
}
