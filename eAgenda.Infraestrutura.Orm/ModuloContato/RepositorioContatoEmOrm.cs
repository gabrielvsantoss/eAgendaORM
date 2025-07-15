

using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.Compartilhado;

namespace eAgenda.Infraestrutura.Orm.ModuloContato
{
    public class RepositorioContatoEmOrm : IRepositorioContato
    {

        private readonly eAgendaDbContext contexto;

        public RepositorioContatoEmOrm(eAgendaDbContext contexto)
        {
            this.contexto = contexto;
        }
        public void CadastrarRegistro(Contato novoRegistro)
        {
            contexto.Contatos.Add(novoRegistro);
            contexto.SaveChanges();
        }

        public bool EditarRegistro(Guid idRegistro, Contato registroEditado)
        {
            var registroSelecionado = SelecionarRegistroPorId(idRegistro);

            if(registroSelecionado is null)
                return false;

            else
            {
                registroSelecionado.AtualizarRegistro(registroEditado);
                return true;
            }
            
        }
        public bool ExcluirRegistro(Guid idRegistro)
        {
            var registroSelecionado = SelecionarRegistroPorId(idRegistro);

            if (registroSelecionado is null)
                return false;


            else
            {
                contexto.Contatos.Remove(registroSelecionado);
                return true;
            }
        }

        public Contato? SelecionarRegistroPorId(Guid idRegistro)
        {
            return contexto.Contatos.FirstOrDefault(x => x.Id.Equals(idRegistro));
        }

        public List<Contato> SelecionarRegistros()
        {
            return contexto.Contatos.ToList();
        }
    }
}
