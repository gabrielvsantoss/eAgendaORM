
using eAgenda.Dominio.ModuloTarefa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class MapeadorItemEmOrm : IEntityTypeConfiguration<ItemTarefa>
    {
        public void Configure(EntityTypeBuilder<ItemTarefa> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Titulo)
                .IsRequired();

            builder.Property(x => x.Concluido)
                .IsRequired();

            builder.HasOne(x => x.Tarefa)
                .WithMany(x => x.Itens);
        }
    }
}
