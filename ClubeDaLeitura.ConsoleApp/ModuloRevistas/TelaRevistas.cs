

using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                CadastrarRevista();
                break;

            case "2":
                //repositorioRevistas.EditarRevista();
                break;

            case "3":
                //repositorioRevistas.ExcluirRevista();
                break;

            case "4":
                //repositorioRevistas.VisualizarRevista();
                break;

            default:
                NotificarCor.ExibirMensagem("Opcção Invalida...!", ConsoleColor.Cyan);
                break;

        }
    }

    private void CadastrarRevista()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando Revista!");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Digite o Titulo da Revista: ");
        string titulo = Console.ReadLine();

        Console.Write("Numero de Edição: ");
        int numEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ano de Publicação. (yyyy): ");
        DateTime anoPublicacao = Convert.ToDateTime(Console.ReadLine());

        repositorioCaixa.SelecionarTodos();
        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Selecione uma Caixa: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        string statusCaixa = "Disponível";

        Caixa caixaObtida = repositorioCaixa.SelecionarPorId(idCaixa);

        Revistas novaRevista = new Revistas(titulo, numEdicao, anoPublicacao, statusCaixa, caixaObtida);

        string revistaValida =  novaRevista.ValidarRevista();

        if(revistaValida.Length > 0)
        {
            NotificarCor.ExibirMensagem(revistaValida, ConsoleColor.Red);
        }







                    //        ○ Título(2 - 100 caracteres)
                    //○ Número da edição(número positivo)
                    //○ Ano de publicação(data válida)
                    //○ Caixa(seleção obrigatória)
    }
}
