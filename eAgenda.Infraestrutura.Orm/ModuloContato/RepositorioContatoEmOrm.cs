

using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.Compartilhado;

namespace eAgenda.Infraestrutura.Orm.ModuloContato
{
    public class RepositorioContatoEmOrm : RepositorioBaseEmOrm<Contato>, IRepositorioContato
    {
        public RepositorioContatoEmOrm(eAgendaDbContext contexto) : base(contexto)
        {
        }
    }
}
