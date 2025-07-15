
using eAgenda.Dominio.ModuloCompromisso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloContato
{
    public class MapeadorCompromissoEmOrm : IEntityTypeConfiguration<Compromisso>
    {
        public void Configure(EntityTypeBuilder<Compromisso> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Assunto)
                .IsRequired();

            builder.Property(x => x.Data)
                .IsRequired();

            builder.Property(x => x.HoraInicio)
                .IsRequired();

            builder.Property(x => x.HoraTermino)
                .IsRequired();

            builder.Property(x => x.Tipo)
                .IsRequired();

            builder.Property(x => x.Local)
                .IsRequired(false);

            builder.Property(x => x.Link)
                .IsRequired(false);

            builder.HasOne(x => x.Contato)
                .WithMany(p => p.Compromissos)
                .IsRequired(false);
        }
    }
}
