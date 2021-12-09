using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Config
{
    public class FilmeConfig : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Nome).IsRequired();
            builder.Property(f => f.AnoLancamento).IsRequired();
            builder.Property(f => f.Genero).IsRequired();
            builder.Property(f => f.FaixaEtaria).IsRequired();
            builder.Property(f => f.Duracao).IsRequired();
            builder.Property(f => f.Sinopse).IsRequired();
            builder.HasMany(c => c.Espectadores).WithOne(p => p.Filme);
        }
    }
}
