using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAgenda.ConsoleApp.Compartilhado;

namespace EAgenda.ConsoleApp.ModuloTarefa
{
    public class RepositorioTarefa : RepositorioBase<Tarefa>
    {
        List<Tarefa> tarefasConcluidas = new();

        public List<Tarefa> ObterTarefasPendentes()
        {
            return registro.FindAll(tarefa => tarefa.listaItems.Equals(true));
        }

        public List<Tarefa> ObterTarefasConcluidas()
        {
            return registro.FindAll(tarefa => tarefa.listaItems.Equals(true));
        }

    }
}
