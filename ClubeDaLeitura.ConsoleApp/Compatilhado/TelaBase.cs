using ClubeDaLeitura.ConsoleApp.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compatilhado;

public abstract class TelaBase
{
    protected string nomeEntidade;
    private RepositorioBase repositorio;

    protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
    }

    public abstract void VisualizarRegistros(bool e); // Método abstract, será importado da classe filho
    public abstract EntidadeBase ObterDados(); // Método abstract, será importado da classe filho


    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"         Gestao de {nomeEntidade}.       ");
        Console.WriteLine("------------------------------------------\n");
    }

    public virtual char ApresentarMenu()
    {
        Console.Clear();
        ExibirCabecalho();

        Console.WriteLine("    ------------------------------");
        Console.WriteLine($"    | [1] Cadastrar {nomeEntidade}        |");
        Console.WriteLine($"    | [2] Visualizar {nomeEntidade}       |");
        Console.WriteLine($"    | [3] Editar {nomeEntidade}           |");
        Console.WriteLine($"    | [4] Excluir {nomeEntidade}          |");
        Console.WriteLine($"    | [S] Sair...                |");
        Console.WriteLine("    ------------------------------");
        Console.Write("    | Escolha uma opção válida: ");

        Console.Write("Escolha uma opção válida: ");
        char opcao = Convert.ToChar(Console.ReadLine()!.ToUpper());

        return opcao;
    }

    public virtual void InserirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine($"Cadastrando {nomeEntidade}.");
        Console.WriteLine("------------------------------------------\n");

        EntidadeBase novoRegistro = ObterDados(); //Método Override da classe filho trazendo dados especificos.

        string ehValido = novoRegistro.Validar();

        if (ehValido.Length > 0)
        {
            Notificar.ExibirMensagem(ehValido, ConsoleColor.Red); return;
        }

        repositorio.CadastrarRegistro(novoRegistro); // Método da classe pai RepositorioBase

        Notificar.ExibirMensagem($"Cadastro de {nomeEntidade} realizado com sucesso!", ConsoleColor.Green);
    }

    public virtual void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine($"Editando {nomeEntidade}.");
        Console.WriteLine("------------------------------------------\n");

        VisualizarRegistros(false); // Método override da classe filho

        Console.WriteLine($"Digite o ID do {nomeEntidade} que deseja editar: ");
        int idRegistro = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        EntidadeBase registroEditado = ObterDados(); // Método override da classe filho

        string ehValido = registroEditado.Validar();

        if (ehValido.Length > 0)
        {
            Notificar.ExibirMensagem(ehValido, ConsoleColor.Red);
            EditarRegistro(); // retorna ao método para nova tentativa(loop)
            return;
        }

        bool conseguiuEditar = repositorio.EditarRegistro(idRegistro, registroEditado); // Método da classe pai RepositorioBase

        if (!conseguiuEditar)
        {
            Notificar.ExibirMensagem($"Edição de {nomeEntidade} falhou! Verifique as informações e tente novmente.", ConsoleColor.Red);
            return;
        }

        Notificar.ExibirMensagem($"Edição de {nomeEntidade} realizada com sucesso!", ConsoleColor.Green);
    }

    public virtual void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine($"Excluindo {nomeEntidade}.");
        Console.WriteLine("------------------------------------------\n");

        VisualizarRegistros(false); // Método override da classe filho

        Console.WriteLine($"Digite o ID do {nomeEntidade} que deseja excluir: ");
        int idRegistro = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        bool conseguiuExcluir = repositorio.ExcluirRegistro(idRegistro); // Método da classe pai RepositorioBase

        if (!conseguiuExcluir)
        {
            Notificar.ExibirMensagem($"Exclusão de {nomeEntidade} falhou! Verifique as informações e tente novmente.", ConsoleColor.Red);
            return;
        }

        Notificar.ExibirMensagem($"Exclusão de {nomeEntidade} realizada com sucesso!", ConsoleColor.Green);
    }
}
