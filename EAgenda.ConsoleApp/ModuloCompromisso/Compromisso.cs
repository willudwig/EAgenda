using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using EAgenda.ConsoleApp.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.ConsoleApp.ModuloCompromisso
{
    public class Compromisso : EntidadeBase
    {
        public string assunto;
        public string local;
        public DateTime dataCompromisso;
        public DateTime horaInicio;
        public string horaTermino = "Não concluído";
        public Contato contatoRelacionado;
        public bool relacao = false;

        public Compromisso(string assunto, string local, DateTime dataCompromisso, DateTime horaInicio, Contato contatoRelacionado)
        {
            this.assunto = assunto;
            this.local = local;
            this.dataCompromisso = dataCompromisso;
            this.horaInicio = horaInicio;
            this.contatoRelacionado = contatoRelacionado;
        }
 
    }
}
