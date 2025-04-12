using ClubeDaLeitura.ConsoleApp.Compatilhado;
using System.Reflection;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo
{
    RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

    private void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("|              Clube da Leitura                     |");
        Console.WriteLine("-----------------------------------------------------\n");
    }

    public void GerenciarAmigos()
    {
        ExibirCabecalho();

        Console.WriteLine("Gerenciamento de Amigos!");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.WriteLine("1 - Inserir Novo Amigo.");
        Console.WriteLine("2 - Editar Amigo Cadastrado.");
        Console.WriteLine("3 - Excluir Amigo Cadastrado.");
        Console.WriteLine("4 - Listar Amigos Cadastrados.");
        Console.WriteLine("5 - Visualizar Emprestimos.");
        Console.WriteLine("-----------------------------------------------------");

        Console.Write("Digite uma opção válida: ");
        string opcao = Console.ReadLine().ToUpper();

        switch (opcao)
        {
            case "1":
                InserirNovoAmigo();
                break;
            case "2":
                EditarAmigoCadastrado();
                break;
            case "3":
                ExcluirAmigoCadastrado();
                break;
            case "4":
                ListarAmigosCadastrados();
                break;
            case "5":
                VisualizarEmprestimos();
                break;
            default:
                CorAdicionada.ExibirMensagem("Opção inválida!", ConsoleColor.Cyan);
                break;
        }
    }

    public void InserirNovoAmigo()
    {
        ExibirCabecalho();

        Console.WriteLine("Inserindo novo Amigo...");
        Console.WriteLine("-----------------------------------------------------\n");

        Amigo novoAmigo = new Amigo("", "", "");
        novoAmigo = ObterDadosAmigo();

        string resultadoValidacao = novoAmigo.ValidarEntradas();

        if (resultadoValidacao.Length > 0)
        {
            CorAdicionada.ExibirMensagem(resultadoValidacao, ConsoleColor.Red);

            return;
        }

        repositorioAmigo.InserirNovoAmigo(novoAmigo);

        CorAdicionada.ExibirMensagem("Amigo Cadastrado Com Sucesso!", ConsoleColor.Green);
        Console.WriteLine("Pressione {Enter]");

    }

    public void EditarAmigoCadastrado()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Amigo Cadastrado...");
        Console.WriteLine("-----------------------------------------------------\n");

        repositorioAmigo.VisualizarAmigosCadastrados();

        Console.Write("Digite o ID do Amigo que deseja Editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Amigo amigoEditado = new Amigo("", "", "");
        amigoEditado = ObterDadosAmigo();

        string resultadoValidacao = amigoEditado.ValidarEntradas();

        if (resultadoValidacao.Length > 0)
        {
            CorAdicionada.ExibirMensagem(resultadoValidacao, ConsoleColor.Red);

            return;
        }

        bool editou = repositorioAmigo.EditarAmigoCadastrado(amigoEditado, idSelecionado);

        if (!editou)
        {
            CorAdicionada.ExibirMensagem("Amigo não encontrado! Edição cancelada", ConsoleColor.Red);
            
            return;
        }

        CorAdicionada.ExibirMensagem("Amigo Editado Com Sucesso!", ConsoleColor.Green);
    }

    public void ExcluirAmigoCadastrado()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo Amigo Cadastrado...");
        Console.WriteLine("-----------------------------------------------------\n");

        repositorioAmigo.VisualizarAmigosCadastrados();

        Console.Write("Digite o ID do Amigo: ");
        int idExcluir = Convert.ToInt32(Console.ReadLine());

        bool excluiu = repositorioAmigo.ExcluirAmigoCadastrado(idExcluir);
        // Criar validação para verificar se o amigo está vinculado a algum empréstimo.

        if (!excluiu)
        {
            CorAdicionada.ExibirMensagem("Houve um erro durante a exclusao do Amigo", ConsoleColor.Red);

            return;
        }
        else
            CorAdicionada.ExibirMensagem("Amigo excluído com sucesso!", ConsoleColor.Green);

    }

    public void ListarAmigosCadastrados()
    {
        ExibirCabecalho();

        Console.WriteLine("Lista de Amigos Cadastrados:");
        Console.WriteLine("-----------------------------------------------------\n");

        repositorioAmigo.VisualizarAmigosCadastrados();

        CorAdicionada.ExibirMensagem("Pressione [Enter] para Continuar...", ConsoleColor.Green);
    }

    public void VisualizarEmprestimos()
    {
        ExibirCabecalho();
        Console.WriteLine("Visualizando Empréstimos...");
        Console.WriteLine("-----------------------------------------------------\n");

        //Criar Metodo ListarEmprestimos dentro da Classe RepositorioEmprestimo.
        //Listar todos os empréstimos cadastrados.
    }

    public Amigo ObterDadosAmigo()
    {
        Console.Write("Digite nome do Amigo: ");
        string nome = Console.ReadLine();

        Console.Write("Digite nome do Responsável: ");
        string responsavel = Console.ReadLine();

        Console.Write("Digite Telefone de contato: ");
        string telefone = Console.ReadLine().Trim(' ');

        Amigo dadosObtidosAmigo = new Amigo(nome, responsavel, telefone);

        return dadosObtidosAmigo;
    }
}