﻿using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Infraestrura.Compartilhado;

namespace eAgenda.Infraestrutura.ModuloTarefa;

public class RepositorioTarefa : IRepositorioTarefa
{
    private readonly ContextoDados contexto;
    private readonly List<Tarefa> registros;

    public RepositorioTarefa(ContextoDados contexto)
    {
        this.contexto = contexto;
        this.registros = contexto.Tarefas;
    }

    public void CadastrarRegistro(Tarefa tarefa)
    {
        registros.Add(tarefa);

        contexto.Salvar();
    }

    public bool EditarRegistro(Guid idTarefa, Tarefa tarefaEditada)
    {
        var tarefaSelecionada = SelecionarRegistroPorId(idTarefa);

        if (tarefaSelecionada is null)
            return false;

        tarefaSelecionada.AtualizarRegistro(tarefaEditada);

        contexto.Salvar();

        return true;
    }

    public bool ExcluirRegistro(Guid idTarefa)
    {
        var registroSelecionado = SelecionarRegistroPorId(idTarefa);

        if (registroSelecionado is null)
            return false;

        registros.Remove(registroSelecionado);

        contexto.Salvar();

        return true;
    }

    public void AdicionarItem(ItemTarefa item)
    {
        contexto.Salvar();
    }

    public bool AtualizarItem(ItemTarefa itemAtualizado)
    {
        contexto.Salvar();

        return true;
    }

    public bool RemoverItem(ItemTarefa item)
    {
        contexto.Salvar();

        return true;
    }

    public Tarefa? SelecionarRegistroPorId(Guid idTarefa)
    {
        return registros.Find(t => t.Id.Equals(idTarefa));
    }

    public List<Tarefa> SelecionarRegistros()
    {
        return registros;
    }

    public List<Tarefa> SelecionarTarefasPendentes()
    {
        return registros.FindAll(t => !t.Concluida);
    }

    public List<Tarefa> SelecionarTarefasConcluidas()
    {
        return registros.FindAll(t => t.Concluida);
    }

    public void AdicionarItem(Guid id, ItemTarefa item)
    {
        throw new NotImplementedException();
    }
}
