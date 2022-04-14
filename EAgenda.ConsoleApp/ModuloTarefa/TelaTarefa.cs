using EAgenda.ConsoleApp.Compartilhado.Interfaces;
using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using System;
using System.Collections.Generic;
using static EAgenda.ConsoleApp.Compartilhado.Superclasses.Notificador;
using static EAgenda.ConsoleApp.ModuloTarefa.Tarefa;

namespace EAgenda.ConsoleApp.ModuloTarefa
{
    public class TelaTarefa : TelaBase, ICadastravel
    {
        RepositorioTarefa repoTarefa;

        string tituloTarefa;
        DateTime dataCriacao;
        Prioridade prioridade = Prioridade.Normal;
        List<Item> listaitens = new();
        Item item;

        public TelaTarefa(RepositorioTarefa repoTar) : base("Cadastro de Tarefa")
        {
            repoTarefa = repoTar;
        }

        public void EditarRegistro()
        {
            MostrarTitulo("Editando Tarefa");

            VisualizarRegistros();

            int numero = ObterNumero();

            repoTarefa.VerificarIdExistente(numero);

            Tarefa tarefaSelecionada = repoTarefa.SelecionarObjeto(numero);

            AlterarTarefa(tarefaSelecionada);

            tarefaSelecionada.CalcularPercentualConclusao(tarefaSelecionada.listaItems);

            repoTarefa.Editar(numero, tarefaSelecionada);

            nota.ApresentarMensagem("Editado com sucesso", TipoMensagem.Sucesso);
        }
        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluindo Tarefa");
            
            VisualizarRegistros();

            int numero = ObterNumero();

            repoTarefa.Excluir(numero);

            nota.ApresentarMensagem("Excluído com sucesso", TipoMensagem.Sucesso);
        }
        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo Tarefa");

            repoTarefa.Inserir(InputarTarefa());

            nota.ApresentarMensagem("\nTarefa inserida com sucesso", TipoMensagem.Sucesso);
        }
        public void VisualizarRegistros()
        {
            Console.Clear();
            MostrarTitulo("Tarefas");

            bool estaVazio = repoTarefa.VerificarSeRegistroVazio();

            if (estaVazio.Equals(true))
            {
                nota.ApresentarMensagem("Registro Vazio", TipoMensagem.Atencao);
                return;
            }
            else
            {
                List<Tarefa> tarefas = repoTarefa.SelecionarTodos();

                foreach (Tarefa item in tarefas)
                {
                    ApresentarInformacoes(item);
                }
            }

            Console.ReadKey();
        }

        #region métodos privados
        private void AlterarTarefa(Tarefa tarefaEditada)
        {
            Console.Clear();
            Console.Write("\nQual campo alterar? [1- Título] [2- Prioridade] [3- Ítens] [4- Marcar como Concluída] > ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o novo título: ");
                    tarefaEditada.titulo = Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("Escolha a nova Prioridade: [1- Baixa] [2- Normal] [3- Alta]");
                    opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            tarefaEditada.prioridade = Prioridade.Baixa;
                            break;
                        case "2":
                            tarefaEditada.prioridade = Prioridade.Normal;
                            break;
                        case "3":
                            tarefaEditada.prioridade = Prioridade.Alta;
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine();
                    ApresentarItens(tarefaEditada.listaItems);
                    Console.Write("\nEscolha um número: ");
                    int idSelec = Convert.ToInt32(Console.ReadLine());
                    Tarefa itemTarefaAlterada = AlterarItem(tarefaEditada, idSelec);
                    tarefaEditada.listaItems[idSelec] = itemTarefaAlterada.listaItems[idSelec];
                    break;
                case "4":
                    Console.WriteLine("Esta tarefa foi marcada como concluída.");
                    tarefaEditada.dataConclusao = DateTime.Now.ToString("dd/MM/yyy");
                    break;

            }
        }
        private Tarefa AlterarItem(Tarefa tarefa, int idSelec)
        {
            string opcao;
            Console.Write("\nQual campo do ítem alterar? [1- Status do ítem] [2- Descrição] > ");
            opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    Console.Write("\nQual o novo status? [1- A Fazer] [2- Fazendo] [3- Feito] > ");
                    opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1":
                            tarefa.listaItems[idSelec].statusConclusao = Item.StatusTarefa.Fazer;
                            break;
                        case "2":
                            tarefa.listaItems[idSelec].statusConclusao = Item.StatusTarefa.Fazendo;
                            break;
                        case "3":
                            tarefa.listaItems[idSelec].statusConclusao = Item.StatusTarefa.Feito;
                            break;
                    }
                    break;
                case "2":
                    Console.Write("Descrição: ");
                    tarefa.listaItems[idSelec].descrição = Console.ReadLine();
                    break;
            }

            return tarefa;
        }
        private Tarefa InputarTarefa()
        {
            while (true)
            {
                Console.Write("Título: ");
                tituloTarefa = Console.ReadLine();

                dataCriacao = DateTime.Today;
                Console.WriteLine("\nData de criação: {0:dd/MM/yyy}", dataCriacao);
                Console.ReadKey();

                string opcao = "";

                while (opcao != "2")
                {
                    Console.Clear();
                    MostrarTitulo("Inserindo Tarefa");
                    Console.Write("\nAdicionar ítem? [1- SIM] [2- NÂO] > ");
                    opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            item = new();
                            Console.Write("\nDescrição: ");
                            item.descrição = Console.ReadLine();
                            listaitens.Add(item);
                            break;

                        case "2":
                            break;

                        default:
                            continue;
                    }

                }

                Console.Clear();
                MostrarTitulo("Inserindo Tarefa");
                Console.Write("\nPrioridade desta tarefa: [1- Baixa] [2- Normal] [3- Alta] > ");
                opcao = Console.ReadLine();

                while (opcao == "1" || opcao == "2" || opcao == "3")
                {
                    switch (opcao)
                    {
                        case "1":
                            prioridade = Prioridade.Baixa;
                            break;
                        case "2":
                            prioridade = Prioridade.Normal;
                            break;
                        case "3":
                            prioridade = Prioridade.Alta;
                            break;
                    }

                    break;
                }

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

            return new(tituloTarefa, listaitens, dataCriacao, prioridade);
        }
        private void ApresentarInformacoes(Tarefa t) 
        {
            Console.WriteLine($"ID: {t.Id} \n\r\n"+
                              $"Título................: {t.titulo}\n\r"+
                              $"Data de criação.......: {t.dataCriacao:dd/MM/yyy}\n\r"+
                              $"Data de conclusão.....: {t.dataConclusao:dd/MM/yyy}\n\r"+
                              $"Prioridade............: {t.prioridade}\n\r"+
                              $"Percentual concluido..: {t.PercentualConclusao}\n\r"+
                              $"\nÍTENS - STATUS\n"
                );

            ApresentarItens(t.listaItems);

            DesenharLinha(70);
        }
        private void ApresentarItens(List<Item> listaItens)
        {
            int numItem = 0;
            foreach (var item in listaItens)
            {
                Console.Write(numItem++ + "> ");
                Console.Write(item.descrição + " - " + item.statusConclusao + "\n");
            }
        }
        protected override string Validar()
        {
            string mensagem = "";

            if (string.IsNullOrEmpty(tituloTarefa))
                mensagem += "Campo 'Título' não pode ser vazio";

            return mensagem;
        }
        #endregion
    }
}
