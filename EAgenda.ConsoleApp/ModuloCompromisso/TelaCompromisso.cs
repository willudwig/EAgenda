using EAgenda.ConsoleApp.Compartilhado.Interfaces;
using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using EAgenda.ConsoleApp.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EAgenda.ConsoleApp.Compartilhado.Superclasses.Notificador;

namespace EAgenda.ConsoleApp.ModuloCompromisso
{
    public class TelaCompromisso : TelaBase
    {
        readonly RepositorioCompromisso repoCompromisso;
        readonly RepositorioContato repoContato;
        readonly TelaContato telaContato;

        public TelaCompromisso(RepositorioCompromisso repositorioCompromisso, RepositorioContato repositorioContato, TelaContato telaContato) : base("Cadastro de Compromisso")
        {
            repoCompromisso = repositorioCompromisso;
            repoContato = repositorioContato;
            this.telaContato = telaContato;
        }

        public override string MostrarOpcoes()
        {
            MostrarTitulo(titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Visualizar Compromissos Passados");
            Console.WriteLine("Digite 6 para Visualizar Compromissos Futuros por Período");

            Console.WriteLine("Digite s para sair\n");
            Console.Write("> ");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void EditarRegistro()
        {
            MostrarTitulo("Editando Compromisso");

            VisualizarRegistros();

            int numero = ObterNumero();

            repoCompromisso.VerificarIdExistente(numero);

            Compromisso compromissoSelecionado = repoCompromisso.SelecionarObjeto(numero);

            Console.Write("\nApenas inserir a hora do término do compromisso? [1- SIM] [2- NÂO] > ");
            string opcao = Console.ReadLine();

            while (true)
            {
                if (opcao.Equals("1"))
                {
                    DateTime termino;
                    Console.Write("\nHora do término: ");
                    DateTime.TryParse(Console.ReadLine(), out termino);
                    compromissoSelecionado.horaTermino = termino.ToString();
                    compromissoSelecionado.Id = numero;
                    break;
                }
                else if (opcao.Equals("2"))
                {
                    compromissoSelecionado.Id = numero;
                    compromissoSelecionado = InputarCompromisso();
                    break;
                }
                else
                {       
                    nota.ApresentarMensagem("Opção inválida", TipoMensagem.Atencao);
                    continue;
                }
            }

            repoCompromisso.Editar(numero, compromissoSelecionado);

            nota.ApresentarMensagem("Editado com sucesso", TipoMensagem.Sucesso);
        }
        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluindo Compromisso");

            VisualizarRegistros();

            int numero = ObterNumero();

            repoCompromisso.Excluir(numero);

            nota.ApresentarMensagem("Excluído com sucesso", TipoMensagem.Sucesso);
        }
        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo Compromisso");

            repoCompromisso.Inserir(InputarCompromisso());

            nota.ApresentarMensagem("\nCompromisso inserido com sucesso", TipoMensagem.Sucesso);
        }
        public void VisualizarRegistros()
        {
            Console.Clear();
            MostrarTitulo("Compromissos");

            bool estaVazio = repoCompromisso.VerificarSeRegistroVazio();

            if (estaVazio.Equals(true))
            {
                nota.ApresentarMensagem("Registro Vazio", TipoMensagem.Atencao);
                return;
            }
            else
            {
                List<Compromisso> compromissos = repoCompromisso.SelecionarTodos();

                foreach (Compromisso item in compromissos)
                {
                    ApresentarInformacoes(item);
                }
            }

            Console.ReadKey();
        }
        public void VisualizarCompromissosPassados()
        {
            Console.Clear();
            MostrarTitulo("Compromissos Passados");

            bool estaVazio = repoCompromisso.VerificarSeRegistroVazio();

            if (estaVazio.Equals(true))
            {
                nota.ApresentarMensagem("Registro Vazio", TipoMensagem.Atencao);
                return;
            }
            else
            {
                List<Compromisso> compromissos = repoCompromisso.SelecionarTodos();
                List<Compromisso> passados = compromissos.FindAll(c => c.horaTermino != "Não concluído").ToList();

                foreach (Compromisso item in passados)
                {
                    ApresentarInformacoes(item);
                }
            }

            Console.ReadKey();
        }
        public void VisualizarCompromissosFuturosPorPeriodo()
        {
            Console.Clear();
            MostrarTitulo("Compromissos Por Período");

            bool estaVazio = repoCompromisso.VerificarSeRegistroVazio();

            if (estaVazio.Equals(true))
            {
                nota.ApresentarMensagem("Registro Vazio", TipoMensagem.Atencao);
                return;
            }
            else
            {
                List<Compromisso> compromissos = repoCompromisso.SelecionarTodos();

                Console.Write("De: ");
                DateTime inicio = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Até: ");
                DateTime fim = Convert.ToDateTime(Console.ReadLine());  
                List<Compromisso> futuros = compromissos.FindAll(c => c.horaInicio >= inicio && c.horaInicio <= fim).ToList();

                foreach (Compromisso item in futuros)
                {
                    ApresentarInformacoes(item);
                }
            }

            Console.ReadKey();
        }

        #region métodos privados
        private Compromisso InputarCompromisso()
        {
            string assunto;
            string local;
            DateTime dataCompromisso;
            DateTime horaInicio;
            Contato contatoRelacionado;

            Console.Write("Assunto: ");
            assunto = Console.ReadLine();

            Console.Write("Local: ");
            local = Console.ReadLine();

            Console.Write("Data do compromisso: ");
            DateTime.TryParse(Console.ReadLine(), out dataCompromisso);

            Console.Write("Hora de início: ");
            DateTime.TryParse(Console.ReadLine(), out horaInicio);

            Console.Write("Nome do contato: ");
            string nome = Console.ReadLine();

            contatoRelacionado = BuscarContatoExistente(nome);

            if (contatoRelacionado != null)
                nota.ApresentarMensagem("O nome digitado está na sua lista de contatos.", TipoMensagem.Sucesso);
            else
            {
                nota.ApresentarMensagem("O nome digitado não está na sua lista de contatos. Por favor, adicione a seguir:\n", TipoMensagem.Atencao);
                telaContato.InserirRegistro();
                contatoRelacionado = BuscarContatoExistente(nome);
            }
  
            return new(assunto, local, dataCompromisso, horaInicio, contatoRelacionado);
        }
        private void ApresentarInformacoes(Compromisso c)
        {
            Console.WriteLine($"ID: {c.Id} \n\r\n" +
                             $"Assunto...........: {c.assunto}\n\r" +
                             $"Local.............: {c.local}\n\r" +
                             $"Data compromisso..: {c.dataCompromisso:d} {c.horaInicio:t}\n\r" +
                             $"Término...........: {c.horaTermino:t}\n\r" +
                             $"\n\r"
                );

            if (c.contatoRelacionado != null)
                ApresentarContatoRelacionado(c.contatoRelacionado);

            DesenharLinha(50);
        }
        private void ApresentarContatoRelacionado(Contato c)
        {
            Console.WriteLine(

                            $"Contato:\n\r" +
                            $"Nome:..........: {c.nome}\n\r" +
                            $"Empresa........: {c.empresaPessoa}\n\r" +
                            $"Cargo/Négócio..: {c.ramoNegocio}\n\r" +
                            $"E-mail.........: {c.email}\n\r" +
                            $"Telefone.......: {c.telefone}"

                );
        }
        private Contato BuscarContatoExistente(string nome)
        {
            List<Contato> contatos = repoContato.SelecionarTodos();
            return contatos.Find(c => c.nome.Equals(nome));
        }

        protected override string Validar()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
