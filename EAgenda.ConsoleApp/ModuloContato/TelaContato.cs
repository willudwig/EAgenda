using EAgenda.ConsoleApp.Compartilhado.Interfaces;
using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EAgenda.ConsoleApp.Compartilhado.Superclasses.Notificador;

namespace EAgenda.ConsoleApp.ModuloContato
{
   
    public class TelaContato : TelaBase, ICadastravel
    {
        RepositorioContato repoContato;

        string nome;
        string email;
        string empresaPessoa;
        string ramoNegocio;
        int telefone;

        public TelaContato(RepositorioContato repoContato) :base("Cadastro de Contato")
        {
            this.repoContato = repoContato;
        }
        public override string MostrarOpcoes()
        {
            MostrarTitulo(titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Visualizar Contatos por Cargo");

            Console.WriteLine("Digite s para sair\n");
            Console.Write("> ");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void EditarRegistro()
        {
            MostrarTitulo("Editando Contato");

            VisualizarRegistros();

            int numero = ObterNumero();

            repoContato.VerificarIdExistente(numero);

            Contato contatoSelecionado = repoContato.SelecionarObjeto(numero);

            contatoSelecionado.Id = numero;
            contatoSelecionado = InputarContato();

            repoContato.Editar(numero, contatoSelecionado);

            nota.ApresentarMensagem("Editado com sucesso", TipoMensagem.Sucesso);
        }
        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluindo Contato");

            VisualizarRegistros();

            int numero = ObterNumero();

            repoContato.Excluir(numero);

            nota.ApresentarMensagem("Excluído com sucesso", TipoMensagem.Sucesso);
        }
        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo Contato");

            repoContato.Inserir(InputarContato());

            nota.ApresentarMensagem("\nContato inserido com sucesso", TipoMensagem.Sucesso);
        }
        public void VisualizarRegistros()
        {
            Console.Clear();
            MostrarTitulo("Contatos");

            bool estaVazio = repoContato.VerificarSeRegistroVazio();

            if (estaVazio.Equals(true))
            {
                nota.ApresentarMensagem("Registro Vazio", TipoMensagem.Atencao);
                return;
            }
            else
            {
                List<Contato> contatos = repoContato.SelecionarTodos();

                foreach (Contato item in contatos)
                {
                    ApresentarInformacoes(item);
                }
            }

            Console.ReadKey();
        }
        public void VisualizarContatosPorCargo() 
        {
            Console.Clear();
            MostrarTitulo("Contatos");

            bool estaVazio = repoContato.VerificarSeRegistroVazio();

            if (estaVazio.Equals(true))
            {
                nota.ApresentarMensagem("Registro Vazio", TipoMensagem.Atencao);
                return;
            }
            else
            {
                List<Contato> contatos = repoContato.SelecionarTodos();

                Console.Write("Digite o cargo ou o negócio: ");
                string cargo = Console.ReadLine();
                List<Contato> cargos = contatos.FindAll(c => c.ramoNegocio.Equals(cargo)).ToList();

                foreach (Contato item in cargos)
                {
                    ApresentarInformacoes(item);
                }
            }

            Console.ReadKey();
        }

        private void ApresentarInformacoes(Contato c)
        {
            Console.WriteLine($"ID: {c.Id} \n\r\n" +
                             $"Nome...........: {c.nome}\n\r" +
                             $"E-mail.........: {c.email}\n\r" +
                             $"Empresa........: {c.empresaPessoa}\n\r" +
                             $"Cargo/Negócio..: {c.ramoNegocio}\n\r" +
                             $"Cargo/Negócio..: {c.telefone}"
               );

            DesenharLinha(50);
        }
        private Contato InputarContato()
        {
            while (true)
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();

                Console.Write("E-mail: ");
                email = Console.ReadLine();

                Console.Write("Empresa do contato: ");
                empresaPessoa = Console.ReadLine();

                Console.Write("Ramo de negócio ou cargo: ");
                ramoNegocio = Console.ReadLine();

                Console.Write("Telefone: ");
                try { telefone = Convert.ToInt32(Console.ReadLine()); }catch(Exception) { nota.ApresentarMensagem("Campo 'Telefone', erro no formato", TipoMensagem.Erro); }

                string status = Validar();

                if (status != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(status);
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else 
                    break;
            }

            return new(nome, email, empresaPessoa, ramoNegocio, telefone);
        }

        protected override string Validar()
        {
            string mensagem = "";

            if (string.IsNullOrEmpty(nome))
                mensagem += "Campo 'Nome' não pode ser vazio\n";

            if (!email.Contains("@"))
                mensagem += "Campo 'E-mail' inválido\n";

            if (string.IsNullOrEmpty(empresaPessoa))
                mensagem += "Campo 'Empresa' não pode ser vazio\n";

            if (telefone.ToString().Length < 8 || telefone.ToString().Length > 9)
                mensagem += "Campo 'Telefone' inválido";

            return mensagem;
        }


    }
    
}
