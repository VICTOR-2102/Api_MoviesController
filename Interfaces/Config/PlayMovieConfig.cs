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
    public class PlayMovieConfig : IEntityTypeConfiguration<PlayMovie>
    {
        public void Configure(EntityTypeBuilder<PlayMovie> builder)
        {   //A Config é a Configuração das entidades que serão criadas no banco de dados a
            //partir do principio de desenvolvimento code first.
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomeDoFilme).IsRequired();
            builder.Property(p => p.NomeDoEspectador).IsRequired();
            builder.Property(p => p.FilmeId).IsRequired();
            builder.Property(p => p.EspectadorId).IsRequired();
        }
    }
}