using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using System.Collections.Generic;
using System.Linq;


namespace EAgenda.ConsoleApp.Compartilhado.Interfaces
{
    public interface ICadastravel
    {
        void InserirRegistro();
        void EditarRegistro();
        void ExcluirRegistro();
        void VisualizarRegistros();
    }
}
