

using ClubeDaLeitura.ConsoleApp.Compatilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;

public class TelaRevistas
{

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
                CadastrarRevista();
                break;

            case "2":
                EditarRevista();
                break;

            case "3":
                ExcluirRevista();
                break;

            case "4":
                VisualizarRevista();
                break;

            default:
                NotificarCor.ExibirMensagem("Opcção Invalida...!", ConsoleColor.Cyan);
                break;

        }
    }

    private void CadastrarRevista()
    {
        throw new NotImplementedException();
    }

    private void EditarRevista()
    {
        throw new NotImplementedException();
    }

    private void ExcluirRevista()
    {
        throw new NotImplementedException();
    }

    private void VisualizarRevista()
    {
        throw new NotImplementedException();
    }
}
