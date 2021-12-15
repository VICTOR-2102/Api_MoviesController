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
    public class EspectadorConfig : IEntityTypeConfiguration<Espectador>
    {
        public void Configure(EntityTypeBuilder<Espectador> builder)
        {
            //A Config é a Configuração das entidades que serão criadas no banco de dados a
            //partir do principio de desenvolvimento code first.
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome).IsRequired();
            builder.Property(e => e.Telefone).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.CPFCNPJ).IsRequired();
            builder.Property(e => e.Endereco).IsRequired();
            builder.Property(e => e.DataDeNascimento).IsRequired();
            builder.Property(e => e.Sexo).IsRequired();
            builder.HasOne(e => e.Filme).WithMany(e => e.Espectadores);
        }
    }
}
