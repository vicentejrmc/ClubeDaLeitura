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
    public RepositorioCaixa repositorioCaixa = new RepositorioCaixa();

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
        Console.Write("Escolha uma opção válida: ");

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
                Notificar.ExibirMensagem("Opcção Invalida...!", ConsoleColor.Cyan);
                break;

        }


    }

    public void CadastrarCaixa()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrar Caixa!");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Digite a Etiqueta da caixa: ");
        string etiqueta = Console.ReadLine()!.Trim(' ');

        string corDaCaixa = EcolherCoresDisponiveis();

        Console.WriteLine($"Cor Escolhida: {corDaCaixa}");

        Console.Write("Quantos dias durarão os emprestimos da caixa? (padrão = 7) ");
        int diasEmprestimo = Convert.ToInt32(Console.ReadLine());

        Caixa novaCaixa = new Caixa(etiqueta, corDaCaixa, diasEmprestimo);


        string caixaEhValida = novaCaixa.ValidarCaixa();

        if (caixaEhValida.Length > 0)
        {
            Notificar.ExibirMensagem(caixaEhValida, ConsoleColor.Red);

            return;
        }

        repositorioCaixa.Inserir(novaCaixa);

        Notificar.ExibirMensagem("Caixa Criada com Sucesso!", ConsoleColor.Green);

    }

    public void EditarCaixa()
    {
        ExibirCabecalho();

        Console.WriteLine("Editar Caixa!");
        Console.WriteLine("-----------------------------------------------------\n");

        VerOuNao();

        ExibirCabecalho();

        Console.WriteLine("Editar Caixa!");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Selecione o Id da Caixa que deseja Editar: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        Console.Write("Insira a Nova etiqueta: ");
        string novaEtiqueta = Console.ReadLine()!.Trim(' ');

        Console.WriteLine("Selecione a Nova Cor.... ");
        string novaCor = EcolherCoresDisponiveis();

        Console.Write("Insira o Novo prazo de emprestimos da caixa: ");
        int novoLimeteDias = Convert.ToInt32(Console.ReadLine());

        Caixa caixaEditada = new Caixa(novaEtiqueta, novaCor, novoLimeteDias);

        bool editou = repositorioCaixa.Editar(idCaixa, caixaEditada);

        if (!editou)
        {
            Notificar.ExibirMensagem("Houve um erro ao tentar editar a caixa! reinicie o precesso!", ConsoleColor.Red);

            return;
        }

        Notificar.ExibirMensagem("Caixa editada com sucesso!", ConsoleColor.Green);

    }

    public void ExcluirCaixa()
    {
        ExibirCabecalho();

        Console.WriteLine("Editar Caixa!");
        Console.WriteLine("-----------------------------------------------------\n");

        VerOuNao();

        ExibirCabecalho();

        Console.WriteLine("Editar Caixa!");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Insira o Id da Caixa que deseja Excluir: ");
        int IdExcluir = Convert.ToInt32(Console.ReadLine());

        bool conseguiuEcluir = repositorioCaixa.Excluir(IdExcluir); // Criar Validação de Caixa sem emprestimos em Aberto.

        if (!conseguiuEcluir)
        {
            Notificar.ExibirMensagem("Não foi possivel Excluir a caixa, Verifique se existe algum emprestimo em Aberto.", ConsoleColor.Red);

            return;
        }

        Notificar.ExibirMensagem("Caixa Excluida com Sucesso!", ConsoleColor.Green);
    }

    public void VisualizarCaixas()
    {
        ExibirCabecalho();

        Console.WriteLine("Gerenciar Caixas!");
        Console.WriteLine("-----------------------------------------------------\n");

        repositorioCaixa.VisualizarCaixas();

        Console.WriteLine("Press [Enter] continuar");
        Console.ReadLine();

    }

    public string EcolherCoresDisponiveis()
    {
        Console.WriteLine("Seleção de Cor da Caixa");
        Console.WriteLine("-----------------------------------------------------");

        Notificar.ExibirCores("1: Red ##", ConsoleColor.Red);
        Notificar.ExibirCores("2: White ##", ConsoleColor.White);
        Notificar.ExibirCores("3: Blue ##", ConsoleColor.Blue);
        Notificar.ExibirCores("4: DarkBlue ##", ConsoleColor.DarkBlue);
        Notificar.ExibirCores("5: Green ##", ConsoleColor.Green);
        Notificar.ExibirCores("6: DarkGreen ##", ConsoleColor.DarkGreen);
        Notificar.ExibirCores("7: Cyan ##", ConsoleColor.Cyan);
        Notificar.ExibirCores("8: DarkCyan ##", ConsoleColor.DarkCyan);
        Notificar.ExibirCores("9: Yellow ##", ConsoleColor.Yellow);
        Notificar.ExibirCores("10: DarkYellow ##", ConsoleColor.DarkYellow);
        Console.WriteLine("-----------------------------------------------------");

        Console.Write("Escolha uma Cor: ");

        string corEscolhida = Console.ReadLine();

        switch (corEscolhida)
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
                Notificar.ExibirMensagem("Opção Invalida!", ConsoleColor.Red);
                Console.WriteLine("Press [Enter] Continuar");
                GerenciarCaixas();
                break;

        }

        return corEscolhida;

    } // Necessita de melhorias Refatorações finais.

    public void VerOuNao()
    {
        Console.Write("Antes de iniciar deseja visualizar as caixas? S/N: ");
        string verOuNao = Console.ReadLine()!.ToUpper();

        if (verOuNao == "S")
        {
            Console.Clear();
            VisualizarCaixas();
            
        }
        Notificar.ExibirMensagem("Pressione [Enter] para continuar.", ConsoleColor.Yellow);
        Console.ReadLine();
    }
}
