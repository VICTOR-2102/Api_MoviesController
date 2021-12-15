using Dominio.Interfaces;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{ 
    /*Repositórios: São classes ou componentes que encapsulam a
    lógica necessária para acessar fontes de dados.Eles centralizam a
    funcionalidade comum de acesso a dados, melhorando a sustentabilidade e
    desacoplando a infraestrutura ou a tecnologia usada para acessar os bancos de
    dados da camada do modelo de domínio.*/
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly BancoContexto BancoContexto;
        public BaseRepositorio(BancoContexto bancoContexto)
        {
            BancoContexto = bancoContexto;  
        }
        // Mostra todos
        public IEnumerable<TEntity> ObterTodos()
        {
            return BancoContexto.Set<TEntity>().ToList();
        }
        // Busca pelo id
        public TEntity ObterPorId(int id)
        {
            return BancoContexto.Set<TEntity>().Find(id);
        }
        // Adiciona um novo
        public void Adicionar(TEntity entity)
        {
            BancoContexto.Set<TEntity>().Add(entity);
            BancoContexto.SaveChanges();
        }
        // Atualiza
        public void Atualizar(TEntity entity)
        {
            BancoContexto.Set<TEntity>().Update(entity);
            BancoContexto.SaveChanges();
        }
        // Remove
        public void Remover(TEntity entity)
        {
            BancoContexto.Set<TEntity>().Remove(entity);
            BancoContexto.SaveChanges();
        }
        // Finaliza o BancoContexto
        public void Dispose()
        {
            BancoContexto.Dispose();
        }
    }
}
