using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.ConsoleApp.Compartilhado.Superclasses
{
    public abstract class TelaBase
    {
        protected string titulo;

        protected Notificador nota = new();

        public TelaBase(string titulo)
        {
            this.titulo = titulo;
        }

        protected void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
        protected int ObterNumero()
        {
            int num;
            while (true) {
                try
                {
                    Console.Write("\n\nEscolha um ID: ");
                    num = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato incorreto");
                    continue;
                }
            }
            return num;
        }
        public virtual string MostrarOpcoes()
        {
            MostrarTitulo(titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair\n");
            Console.Write("> ");

            string opcao = Console.ReadLine();

            return opcao;
        }
        protected void DesenharLinha(int tamanho)
        {
            Console.WriteLine();

            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
        protected abstract string Validar();

    }
}
