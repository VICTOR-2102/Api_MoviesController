using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Contexto
{
    public class BancoContexto : DbContext
    {
        DbSet<Filme> Filmes { get; set; }
        DbSet<Espectador> Espectadores { get; set; }

        public BancoContexto(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new FilmeConfig())
                .ApplyConfiguration(new EspectadorConfig());
        }
    }
}
