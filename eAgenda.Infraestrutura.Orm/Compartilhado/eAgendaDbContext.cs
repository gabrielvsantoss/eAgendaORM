using eAgenda.Dominio.ModuloContato;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using Microsoft.EntityFrameworkCore;
using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Infraestrutura.Orm.ModuloDespesa;
using eAgenda.Dominio.ModuloTarefa;

namespace eAgenda.Infraestrutura.Orm.Compartilhado
{
    public class eAgendaDbContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Compromisso> Compromissos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<ItemTarefa> Itens { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public eAgendaDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorContatoEmOrm());
            var assembly = typeof(eAgendaDbContext).Assembly;
            modelBuilder.ApplyConfiguration(new MapeadorDespesaEmOrm());
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
