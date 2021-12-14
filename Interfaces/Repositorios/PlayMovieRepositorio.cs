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
    public class PlayMovieRepositorio : BaseRepositorio<PlayMovie>, IPlayMovieRepositorio
    {
        public PlayMovieRepositorio(BancoContexto bancoContexto) : base(bancoContexto) { }
    }
}
