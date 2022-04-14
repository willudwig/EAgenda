using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.ConsoleApp.Compartilhado.Superclasses
{
    public abstract class EntidadeBase
    {
        public Notificador nota = new();
        public int Id { get; set; }


        public abstract string Validar();

 
    }
}
