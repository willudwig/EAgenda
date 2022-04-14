using EAgenda.ConsoleApp.Compartilhado;
using EAgenda.ConsoleApp.Compartilhado.Interfaces;
using EAgenda.ConsoleApp.Compartilhado.Superclasses;
using EAgenda.ConsoleApp.ModuloCompromisso;
using EAgenda.ConsoleApp.ModuloContato;
using System;

namespace EAgenda.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal menuPrincipal = new();

            while (true)
            {
                TelaBase telaSelecionada = menuPrincipal.ObterTela();

                string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                if (telaSelecionada is ICadastravel)
                {
                    ICadastravel telaCadastroBasico = (ICadastravel)telaSelecionada;

                    switch (opcaoSelecionada)
                    {
                        case "1":
                            telaCadastroBasico.InserirRegistro();
                            break;
                        case "2":
                            telaCadastroBasico.EditarRegistro();
                            break;
                        case "3":
                            telaCadastroBasico.ExcluirRegistro();
                            break;
                        case "4":
                            telaCadastroBasico.VisualizarRegistros();
                            break;
                    }

                    if (telaSelecionada is TelaCompromisso)
                    {
                        TelaCompromisso telaCompromisso = (TelaCompromisso)telaSelecionada;
                        switch (opcaoSelecionada)
                        {
                            case "5":
                                telaCompromisso.VisualizarCompromissosPassados();
                                break;
                            case "6":
                                telaCompromisso.VisualizarCompromissosFuturosPorPeriodo();
                                break;
                            default:
                                break;
                        }
                    }

                    if (telaSelecionada is TelaContato)
                    {
                        TelaContato telaCompromisso = (TelaContato)telaSelecionada;
                        switch (opcaoSelecionada)
                        {
                            case "5":
                                telaCompromisso.VisualizarContatosPorCargo();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
        
