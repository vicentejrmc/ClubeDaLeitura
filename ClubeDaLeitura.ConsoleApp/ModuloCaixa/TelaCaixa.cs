using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class TelaCaixa
{
    RepositorioCaixa repositorioCaixa = new RepositorioCaixa();

    private void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("|              Clube da Leitura                     |");
        Console.WriteLine("-----------------------------------------------------\n");
    }

    public void GerenciarCaixas()
    {
        ExibirCabecalho();

        Console.WriteLine("Gerenciar Caixas!");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.WriteLine("1 - Cadastrar nova caixa.");
        Console.WriteLine("2 - Editar Caixa existente.");
        Console.WriteLine("3 - Excluir Caixa.");
        Console.WriteLine("4 - Visualizar Caixas.");
        Console.WriteLine("-----------------------------------------------------\n");

        string opcao = Console.ReadLine().ToUpper();

        switch (opcao)
        {
            case "1":
                CadastrarCaixa();
                break;

            case "2":
                EditarCaixa();
                break;

            case "3":
                ExcluirCaixa();
                break;

            case "4":
                VisualizarCaixas();
                break;

            default:
                CorAdicionada.ExibirMensagem("Opcção Invalida...!", ConsoleColor.Cyan);
                break;

        }


    }

    private void CadastrarCaixa()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrar Caixa!");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Digite a Etiqueta da caixa: ");
        string etiqueta = Console.ReadLine()!.Trim(' ');

        string corDaCaixa = EcolherCoresDisponiveis();
       
        Console.WriteLine($"Cor Escolhida: {corDaCaixa}");

        Console.ReadLine();

    }

    private void EditarCaixa()
    {
        throw new NotImplementedException();
    }

    private void ExcluirCaixa()
    {
        throw new NotImplementedException();
    }

    private void VisualizarCaixas()
    {
        throw new NotImplementedException();
    }

    public string EcolherCoresDisponiveis()
    {
        Console.WriteLine("Seleção de Cor da Caixa");
        Console.WriteLine("-----------------------------------------------------");

        CorAdicionada.ExibirCores("1: Red ##", ConsoleColor.Red);
        CorAdicionada.ExibirCores("2: White ##", ConsoleColor.White);
        CorAdicionada.ExibirCores("3: Blue ##", ConsoleColor.Blue);
        CorAdicionada.ExibirCores("4: DarkBlue ##", ConsoleColor.DarkBlue);
        CorAdicionada.ExibirCores("5: Green ##", ConsoleColor.Green);
        CorAdicionada.ExibirCores("6: DarkGreen ##", ConsoleColor.DarkGreen);
        CorAdicionada.ExibirCores("7: Cyan ##", ConsoleColor.Cyan);
        CorAdicionada.ExibirCores("8: DarkCyan ##", ConsoleColor.DarkCyan);
        CorAdicionada.ExibirCores("9: Yellow ##", ConsoleColor.Yellow);
        CorAdicionada.ExibirCores("10: DarkYellow ##", ConsoleColor.DarkYellow);
        Console.WriteLine("-----------------------------------------------------");

        Console.Write("Escolha uma Cor: ");

        string corEscolhida = Console.ReadLine();

        switch(corEscolhida)
        {
            case "1":
                corEscolhida = "Red";
                break;

            case "2":
                corEscolhida = "White";
                break;
            case "3":
                corEscolhida = "Blue";
                break;
            case "4":
                corEscolhida = "DarkBlue";
                break;
            case "5":
                corEscolhida = "Green";
                break;
            case "6":
                corEscolhida = "DarkGrenn";
                break;
            case "7":
                corEscolhida = "Cyan";
                break;
            case "8":
                corEscolhida = "DarkCyan";
                break;
            case "9":
                corEscolhida = "Yellow";
                break;
            case "10":
                corEscolhida = "DarkYellow";
                break;
            default:
                CorAdicionada.ExibirMensagem("Opção Invalida!", ConsoleColor.Red);
                break;

        }

        return corEscolhida;

    }
}
