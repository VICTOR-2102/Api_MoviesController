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
        // O contexto contém o DbContext e os DbSet’s que representam as
        //entidades no banco de dados.
        DbSet<Filme> Filmes { get; set; }
        DbSet<Espectador> Espectadores { get; set; }
        DbSet<PlayMovie> PlayMovies { get; set; }
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BancoContexto(DbContextOptions options) : base(options) { }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContexto).Assembly);
            modelBuilder
                .ApplyConfiguration(new FilmeConfig())
                .ApplyConfiguration(new PlayMovieConfig())
                .ApplyConfiguration(new EspectadorConfig());
        }
    }
}
