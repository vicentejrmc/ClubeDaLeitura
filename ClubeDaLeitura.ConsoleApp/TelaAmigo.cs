namespace ClubeDaLeitura.ConsoleApp;

public class TelaAmigo
{
    RepositorioAmigo[] repositorioAmigo = new RepositorioAmigo[100];

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
                Console.WriteLine("Opção inválida! Tente novamente.");
                break;
        }
    }

    public void InserirNovoAmigo()
    {
        ExibirCabecalho();

        Console.WriteLine("Inserindo novo Amigo...");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Digite o nome do Amigo: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o nome do Responsável: ");
        string nomeResponsavel = Console.ReadLine();

        Console.Write("Digite o Telefone de contato: ");
        string telefone = Console.ReadLine().Trim();

        Amigo amigo = new Amigo("", "", "");

        amigo = new Amigo(nome, nomeResponsavel, telefone);

        string resultadoValidacao = amigo.ValidarEntradas();

        if(resultadoValidacao.Length > 0)
        {
            Notificador.ExibirMensagem(resultadoValidacao, ConsoleColor.Red);

            return;
        }

        // Criar Metod para Validar conflito de dados inseridos Classe Amigo



        //Criar Metodo Inserir dentro da Classe RepositorioAmigo.



    }

    public void EditarAmigoCadastrado()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Amigo Cadastrado...");
        Console.WriteLine("-----------------------------------------------------\n");
        
        Console.Write("Digite o ID do Amigo: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Digite o novo nome do Amigo: ");
        string nome = Console.ReadLine();
        
        Console.Write("Digite o novo nome do Responsável: ");
        string nomeResponsavel = Console.ReadLine();
       
        Console.Write("Digite o novo Telefone de contato: ");
        string telefone = Console.ReadLine();
    }

    public void ExcluirAmigoCadastrado()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo Amigo Cadastrado...");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Digite o ID do Amigo: ");
        int id = Convert.ToInt32(Console.ReadLine());

        //Criar Metodo Obter AmigoPorId dentro da Classe RepositorioAmigo.
    }

    public void ListarAmigosCadastrados()
    {
        ExibirCabecalho();
        Console.WriteLine("Listando Amigos Cadastrados...");
        Console.WriteLine("-----------------------------------------------------\n");
        
        //Criar Metodo ListarAmigos dentro da Classe RepositorioAmigo.
        //Listar todos os amigos cadastrados.
    }

    public void VisualizarEmprestimos()
    {
        ExibirCabecalho();
        Console.WriteLine("Visualizando Empréstimos...");
        Console.WriteLine("-----------------------------------------------------\n");

        //Criar Metodo ListarEmprestimos dentro da Classe RepositorioEmprestimo.
        //Listar todos os empréstimos cadastrados.
    }


}