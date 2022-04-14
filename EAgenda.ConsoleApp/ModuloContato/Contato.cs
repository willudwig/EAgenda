using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.ConsoleApp.ModuloContato
{
    public class Contato : EntidadeBase
    {
        public string nome;
        public string email;
        public string empresaPessoa;
        public string ramoNegocio;
        public int telefone;

        public Contato(string nome, string email, string empresaPessoa, string ramoNegocio, int telefone)
        {
            this.nome = nome;
            this.email = email;
            this.empresaPessoa = empresaPessoa;
            this.ramoNegocio = ramoNegocio;
            this.telefone = telefone;
        }
    }
}
