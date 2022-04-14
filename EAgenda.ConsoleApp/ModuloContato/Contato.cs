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

            string status = Validar();

            if(status != "VÁLIDO")
            {
                Console.WriteLine(status);
                Console.ReadKey();
                return;
            }
        }

        public override string Validar()
        {
            string mensagem = "VÁLIDO";

            if (string.IsNullOrEmpty(nome))
                mensagem += "Campo 'Nome' não pode ser vazio";

            if (!email.Contains("@"))
                mensagem += "Campo 'E-mail' inválido";

            if (string.IsNullOrEmpty(empresaPessoa))
                mensagem += "Campo 'Empresa' não pode ser vazio";

            if (telefone.ToString().Length < 8 || telefone.ToString().Length > 9)
                mensagem += "Campo 'Telefone' inválido";

            return mensagem;
        }
    }
}
