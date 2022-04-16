using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using System;
using System.Collections.Generic;


namespace EAgenda.ConsoleApp.ModuloTarefa
{
    public class Tarefa: EntidadeBase, IComparable<Tarefa>
    {
        public string titulo;
        public DateTime dataCriacao;
        public string dataConclusao = "Não concluída";
        public Prioridade prioridade;
        public List<Item> listaItems = new();
        public string PercentualConclusao { get; set; }

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

        public int CompareTo(Tarefa other)
        {
            if (other.prioridade == Prioridade.Alta)
                return 1;
            if (other.prioridade == Prioridade.Normal)
                return 0;

            return -1;
        }

    }
}
