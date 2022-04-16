using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using System;
using System.Collections.Generic;


namespace EAgenda.ConsoleApp.ModuloTarefa
{
    public class RepositorioTarefa : RepositorioBase<Tarefa>
    {
        List<Tarefa> tarefasConcluidas = new();

        public List<Tarefa> ObterTarefasPendentes()
        {
            List<Tarefa> tarefas = SelecionarTodos();

            List<Tarefa> pendentes = tarefas.FindAll(t => !t.PercentualConclusao.Equals("0%"));

            return pendentes;

        }
        public List<Tarefa> ObterTarefasConcluidas()
        {
            List<Tarefa> tarefas = SelecionarTodos();

            List<Tarefa> concluidas = tarefas.FindAll(t => t.PercentualConclusao.Equals("0%"));

            return concluidas;
        }

    }
}
