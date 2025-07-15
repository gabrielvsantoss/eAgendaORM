﻿
using eAgenda.Dominio.ModuloDespesa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloDespesa
{
    public class MapeadorDespesaEmOrm : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .IsRequired();

            builder.Property(x => x.Descricao)
                .IsRequired();

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.Property(x => x.DataOcorencia)
                .IsRequired();

            builder.Property(x => x.FormaPagamento)
                .IsRequired();

            builder.HasMany(x => x.Categorias)
                .WithMany(x => x.Despesas);

        }
    }
}
