

using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Infraestrutura.Orm.Compartilhado;

namespace eAgenda.Infraestrutura.Orm.ModuloCompromisso
{
    public class RepositorioCompromissoEmOrm : RepositorioBaseEmOrm<Compromisso>, IRepositorioCompromisso
    {
        public RepositorioCompromissoEmOrm(eAgendaDbContext contexto) : base(contexto)
        {
        }
    }
}
