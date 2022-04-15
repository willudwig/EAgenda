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

            List<Tarefa> pendentes = new();

            for ( int i = 0 ; i < tarefas.Count; i++)
            {
                if(tarefas[i].PercentualConclusao != "0%")
                   pendentes.Add(tarefas[i]);
            }
            
            return pendentes;

        }
        public List<Tarefa> ObterTarefasConcluidas()
        {
            List<Tarefa> tarefas = SelecionarTodos();

            List<Tarefa> concluidas = new();

            for (int i = 0; i < tarefas.Count; i++)
            {
                if (tarefas[i].PercentualConclusao.Equals("0%"))
                    concluidas.Add(tarefas[i]);
            }

            return concluidas;
        }

    }
}
