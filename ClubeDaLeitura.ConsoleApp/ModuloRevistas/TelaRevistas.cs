

using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;

public class TelaRevistas
{
    public RepositorioRevistas repositorioRevistas = new RepositorioRevistas();
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


        string opcao = Console.ReadLine().ToUpper();

        switch (opcao)
        {
            case "1":
                repositorioCaixa.CadastrarRevista();
                break;

            case "2":
                repositorioCaixa.EditarRevista();
                break;

            case "3":
                repositorioCaixa.ExcluirRevista();
                break;

            case "4":
                repositorioCaixa,VisualizarRevista();
                break;

            default:
                NotificarCor.ExibirMensagem("Opcção Invalida...!", ConsoleColor.Cyan);
                break;

        }
    }

}
