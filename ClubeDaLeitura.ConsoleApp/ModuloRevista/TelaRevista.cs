

using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;

public class TelaRevista
{
    public RepositorioRevista repositorioRevista = new RepositorioRevista();
    public RepositorioCaixa repositorioCaixa = new RepositorioCaixa();

    private void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("|              Clube da Leitura                     |");
        Console.WriteLine("-----------------------------------------------------\n");
    }
    public void GerenciarRevistas()
    {
        ExibirCabecalho();

        Console.WriteLine("Gerenciar Revistas!");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.WriteLine("1 - Cadastrar Revista.");
        Console.WriteLine("2 - Editar Revista.");
        Console.WriteLine("3 - Excluir Revista.");
        Console.WriteLine("4 - Visualizar Revistas.");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.WriteLine("Escolha uma Opção Válida: ");
        string opcao = Console.ReadLine().ToUpper();

        switch (opcao)
        {
            case "1":
                CadastrarRevista();
                break;

            case "2":
                EditarRevista();
                break;

            case "3":
                ExcluirRevista();
                break;

            case "4":
                VisualizarRevistas();
                break;

            default:
                Notificar.ExibirMensagem("Opcção Invalida...!", ConsoleColor.Cyan);
                break;

        }
    }

    public void CadastrarRevista()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando Revista!");
        Console.WriteLine("-----------------------------------------------------\n");

        bool caixaVazia = true;
        for (int i = 0; i < repositorioCaixa.vetorDeCaixa.Length; i++)
        {
            if (repositorioCaixa.vetorDeCaixa[i] != null)
                caixaVazia = true;
        }

        if (!caixaVazia)
        {
            Notificar.ExibirMensagem("Você Precisa Criar uma caixa antes de Cadastrar uma nova Revista!", ConsoleColor.Red);

            return;
        }

        Console.Write("Digite o Titulo da Revista: ");
        string titulo = Console.ReadLine();

        Console.Write("Numero de Edição: ");
        int numEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ano de Publicação. (yyyy): ");
        int anoPublicacao = Convert.ToInt32(Console.ReadLine());

       repositorioCaixa.VisualizarCaixas();

        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Selecione uma Caixa: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        string statusCaixa = "Disponível";

        Caixa caixaObtida = repositorioCaixa.SelecionarPorId(idCaixa);

        Revista novaRevista = new Revista(titulo, numEdicao, anoPublicacao, statusCaixa, caixaObtida);

        string revistaValida = novaRevista.ValidarRevista();

        if (revistaValida.Length > 0)
        {
            Notificar.ExibirMensagem(revistaValida, ConsoleColor.Red);

            return;
        }

        repositorioRevista.CadastrarRevista(novaRevista);


        Notificar.ExibirMensagem("Revista Cadastrada...", ConsoleColor.Green);
    }

    public void EditarRevista()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Revista!");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Deseja visualizar revistas? S/N: ");
        string simNao = Console.ReadLine().ToUpper();

        if (simNao == "S")
            VisualizarRevistas();

        Console.Write("Selecione o Id da Revista que deseja editar: ");
        int idEditarRevista = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o Titulo da Revista: ");
        string titulo = Console.ReadLine();

        Console.Write("Numero de Edição: ");
        int numEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ano de Publicação. (yyyy): ");
        int anoPublicacao = Convert.ToInt32(Console.ReadLine());

        repositorioCaixa.VisualizarCaixas();
        Console.Write("Selecione uma Caixa: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        Caixa caixa = repositorioCaixa.SelecionarPorId(idCaixa);

        Console.Write("Status atual da Revista: [1 - Disponivel] [2 - Emprestada] [3 - Reservada]");
        int statusRevista = Convert.ToInt32(Console.ReadLine());

        string statusAtual = "";
        switch (statusRevista)
        {
            case 1:
                statusAtual = "Disponível";
                break;
            case 2:
                statusAtual = "Emprestada";
                break;
            case 3:
                statusAtual = "Reservada";
                break;

        }

        Revista revistaEditada = new Revista(titulo, numEdicao, anoPublicacao, statusAtual, caixa);

        string ehValida = revistaEditada.ValidarRevista();

        if (ehValida.Length > 0)
        {
            Notificar.ExibirMensagem(ehValida, ConsoleColor.Red);

            return;
        }

        repositorioRevista.Editar(idEditarRevista, revistaEditada);

        Notificar.ExibirMensagem("Revista Editada com Sucesso!", ConsoleColor.Green);
    }

    public void ExcluirRevista()
    {
        ExibirCabecalho();

        Console.WriteLine("Ecluir Revista!");
        Console.WriteLine("-----------------------------------------------------\n");

        VisualizarRevistas();

        Console.WriteLine("Selecione o Id da Revista que deseja Excluir: ");
        int idExcluir = Convert.ToInt32(Console.ReadLine());

        Revista excluir = repositorioRevista.SelecionarPorId(idExcluir);

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
            "IdRevista", "Titulo", "Num. Edição", "Ano Edição", "Status", "CaixaAtual"
        );
        Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
               excluir.IdRevista, excluir.TituloRevista, excluir.NumEdicao, excluir.AnoEdicao, excluir.StatusEmprestimo, excluir.CaixaAtual
           );

        Console.Write("\nComfirmar Exclusão? S/N ");
        string simNao = Console.ReadLine().ToUpper();

        if (simNao == "S")
        {
            bool excluiu = repositorioRevista.Excluir(idExcluir);

            if (excluiu)
                Notificar.ExibirMensagem("Revista Excluida com Sucesso!", ConsoleColor.Green);
        }
        else if (simNao == "N")
            Notificar.ExibirMensagem("Exclusão Cancelada!", ConsoleColor.Cyan);

        else
            Notificar.ExibirMensagem("Hove um Erro durante a exclusão! tente novamente!", ConsoleColor.Red);
    }

    public void VisualizarRevistas()
    {
        ExibirCabecalho();

        Console.WriteLine("Visualizando Revistas...");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine();

        Revista[] revistasCadastradas = repositorioRevista.SelecionarRevistas();

        for (int i = 0; i < revistasCadastradas.Length; i++)
        {
            Revista rev = revistasCadastradas[i];

            if (rev == null) continue;

            Console.WriteLine($"Id: {rev.TituloRevista} | Titulo: {rev.NumEdicao} |  Edição: {rev.AnoEdicao} | Ano: {rev.AnoEdicao} | Status: {rev.StatusEmprestimo} |   Caixa: {rev.CaixaAtual}");
        }



    }

}
