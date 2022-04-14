using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using EAgenda.ConsoleApp.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.ConsoleApp.ModuloCompromisso
{
    public  class RepositorioCompromisso : RepositorioBase<Compromisso>
    {
        public List<Compromisso> ObterCompromissosPassados()
        {
            return registro.FindAll(c => c.horaTermino != "Não concluído").ToList();
        }

        public List<Compromisso> ObterCompromissosFuturosPorPeriodos(DateTime inicio, DateTime limite)
        {
            List<Compromisso> lista = registro.FindAll(c => c.horaTermino.Equals(null));

            return lista.Where(c => c.horaInicio >= inicio && c.horaInicio <= limite).ToList();
        }
      
    }
}
