using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.ConsoleApp.Compartilhado.Superclasses
{
    public abstract class RepositorioBase<Generico> where Generico : EntidadeBase
    {
        protected List<Generico> registro = new();

        public string Inserir(Generico objeto)
        {
            objeto.Id = ObterNovoID();

            string status = Validar();

            if (status != "Válido")
                return status;

            registro.Add(objeto);

            return status;
        }
        public void Editar(int IdSelecionado, Generico objeto)
        {
            Generico obj = registro.Find(r => r.Id.Equals(IdSelecionado));

            registro[ registro.IndexOf(obj) ] = objeto;
        }
        public void Excluir(int IdSelecionado)
        {
            Generico x = registro.Find(r => r.Id.Equals(IdSelecionado));

            registro.Remove(x);
        }
        public List<Generico> SelecionarTodos()
        {
            return registro;
        }
        public Generico SelecionarObjeto(int IdSelecionado)
        {
            Generico obj = registro.Find(r => r.Id.Equals(IdSelecionado));

            return obj;
        }
        public bool VerificarIdExistente(int IdSelecionado)
        {
            Generico x = registro.Find(r => r.Id.Equals(IdSelecionado));

            if (x != null)
                return true;
            else
                return false;
        }

        public bool VerificarSeRegistroVazio()
        {
            if (registro.Count.Equals(0))
                return true;
            else
                return false;
        }

        public string Validar()
        {
            return "Válido";
        }

        private int ObterNovoID()
        {
            return registro.Count;
        }
    }
}
