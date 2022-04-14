using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.ConsoleApp.ModuloContato
{
    public class RepositorioContato : RepositorioBase<Contato>
    {
        public List<Contato> ObterContatoPorCargo(string cargo)
        {
            return registro.FindAll(c => c.ramoNegocio.Equals(cargo)).ToList();
        }
    }
}
