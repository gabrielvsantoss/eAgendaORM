

using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Infraestrutura.Orm.Compartilhado;

namespace eAgenda.Infraestrutura.Orm.ModuloCategoria
{
    public class RepositorioCategoriaEmOrm : RepositorioBaseEmOrm<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoriaEmOrm(eAgendaDbContext contexto) : base(contexto)
        {
        }
    }
}
