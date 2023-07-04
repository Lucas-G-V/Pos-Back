using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarmitariaReal.Domain.Entities;

namespace MarmitariaReal.Repositories.Mappings
{
    public class ReceitaMapping : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.HasKey(p => p.ReceitaId);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Preco)
                .IsRequired();

            builder.Property(p => p.UrlImagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.ToTable("Receitas");
        }
    }
}
