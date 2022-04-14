using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.ConsoleApp.ModuloTarefa
{
    public class Tarefa: EntidadeBase
    {
        public string titulo;
        public DateTime dataCriacao;
        public string dataConclusao = "Não concluída";
        public Prioridade prioridade;
        public List<Item> listaItems = new();
        public string PercentualConclusao { get; private set; }

        public Tarefa(string titulo, List<Item> listaItems, DateTime dataCriacao, Prioridade prioridade)
        {
            this.titulo = titulo;
            this.dataCriacao = dataCriacao;
            this.prioridade = prioridade;
            this.listaItems = listaItems;
        }

        public enum Prioridade { Baixa, Normal, Alta }

        public void CalcularPercentualConclusao(List<Item> lista)
        {
            int itensFeitos = lista.FindAll(l => l.statusConclusao.Equals(Item.StatusTarefa.Feito)).Count;

            PercentualConclusao =  "" + (itensFeitos * 100) / listaItems.Count + "%";
        }

    }
}
