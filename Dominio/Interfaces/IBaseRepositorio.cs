using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IBaseRepositorio<Tentity> : IDisposable where Tentity : class
    {
        void Adicionar(Tentity entity);
        Tentity ObterPorId(int id);
        IEnumerable<Tentity> ObterTodos();
        void Atualizar(Tentity entity);
        void Remover(Tentity entity);
    }
}
