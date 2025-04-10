

namespace ClubeDaLeitura.ConsoleApp
{
    public class TelaAmigo
    {
        public void ExibirCabecalho()
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

            switch(opcao)
            {
                case "1":
                    InserirNovoAmigo();
                    break;
                case "2":
                    // EditarAmigoCadastrado();
                    break;
                case "3":
                    // ExcluirAmigoCadastrado();
                    break;
                case "4":
                    // ListarAmigosCadastrados();
                    break;
                case "5":
                    // VisualizarEmprestimos();
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
            string telefone = Console.ReadLine();
        }
    }
}