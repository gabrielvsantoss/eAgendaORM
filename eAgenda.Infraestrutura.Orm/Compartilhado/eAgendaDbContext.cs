using eAgenda.Dominio.ModuloContato;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.Compartilhado
{
    public class eAgendaDbContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

    }
}
