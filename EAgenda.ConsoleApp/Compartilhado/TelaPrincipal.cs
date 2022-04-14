using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using EAgenda.ConsoleApp.ModuloCompromisso;
using EAgenda.ConsoleApp.ModuloContato;
using EAgenda.ConsoleApp.ModuloTarefa;
using System;

namespace EAgenda.ConsoleApp.Compartilhado
{
    public class TelaPrincipal
    {
        readonly RepositorioTarefa repositTarefa;
        readonly RepositorioContato repositContato;
        readonly RepositorioCompromisso repositCompromisso;
      
        readonly TelaTarefa telaTarefa;
        readonly TelaContato telaContato;
        readonly TelaCompromisso telaCompromisso;

        public TelaBase ObterTela()
        {
            TelaBase tela = null;

            while (true)
            {
                string opcao = MostrarOpcoes();

                switch (opcao)
                {
                    case "1":
                        tela = telaTarefa;
                        break;
                    case "2":
                        tela = telaContato;
                        break;
                    case "3":
                        tela = telaCompromisso;
                        break;
                    case "s":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }

                break;
            }

            return tela;
        }

        private string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Agenda 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Cadastrar Tarefas");
            Console.WriteLine("Digite 2 para Cadastrar Contatos");
            Console.WriteLine("Digite 3 para Cadastrar Compromissos");

            Console.WriteLine("Digite s para sair\n");
            Console.Write("> ");

            string opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaPrincipal()
        {
            repositTarefa = new();
            repositContato = new();
            repositCompromisso = new();

            telaTarefa = new(repositTarefa);
            telaContato = new(repositContato);
            telaCompromisso = new(repositCompromisso, repositContato, telaContato);
        }
    }
}
