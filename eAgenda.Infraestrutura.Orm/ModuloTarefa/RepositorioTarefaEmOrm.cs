

using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class RepositorioTarefaEmOrm : RepositorioBaseEmOrm<Tarefa>, IRepositorioTarefa
    {

        private readonly eAgendaDbContext contexto;
        public RepositorioTarefaEmOrm(eAgendaDbContext contexto) : base(contexto)
        {
            this.contexto = contexto;
        }

        public void AdicionarItem(Guid tarefaId, ItemTarefa item)
        {
            var tarefa = contexto.Tarefas
                     .Include(t => t.Itens)   // importante carregar a coleção
                     .FirstOrDefault(t => t.Id == tarefaId);

            if (tarefa == null)
                throw new Exception("Tarefa não encontrada");

            // 2. Adiciona o item na coleção de Itens da Tarefa
            tarefa.Itens.Add(item);

            // 3. Salva as alterações
            contexto.SaveChanges();
        }

        public bool AtualizarItem(ItemTarefa itemAtualizado)
        {
            contexto.Itens.Update(itemAtualizado);
            contexto.SaveChanges();
            return true;
        }

        public bool RemoverItem(ItemTarefa item)
        {
            contexto.Itens.Remove(item);
            return true;
        }

        public List<Tarefa> SelecionarTarefasConcluidas()
        {
           return contexto.Tarefas
                .Include(t => t.Itens)
                .Where(t => t.Concluida)
                .ToList();
        }

        public List<Tarefa> SelecionarTarefasPendentes()
        {
            return contexto.Tarefas
                .Include(t => t.Itens)
                .Where(t => !t.Concluida)
                .ToList();
        }
    }
}
