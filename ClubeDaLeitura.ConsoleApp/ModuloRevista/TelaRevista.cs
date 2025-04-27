using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

//Criar metodo interno validar Emprestimo de revista dado seu status "emprestada" ou "disponivel" ou "Reservada"

public class TelaRevista : TelaBase<Revista>, ItelaCrud
{
    public RepositorioRevista repositorioRevista;
    public RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa) : base("Revista", repositorioRevista) // construtor de Tela para TelaRevista
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }

    public override Revista ObterDados()
    {
        TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
        telaCaixa.VisualizarRegistros();

        Console.Write("Selecione o Id caixa onde a revista será guarada: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        Caixa caixaSelecionada = repositorioCaixa.SelecionarRegistroPorId(idCaixa);

        Console.Write("Digite o Título da Revista: ");
        string titulo = Console.ReadLine()!;

        Console.Write("Digite o Numero de Edição da Revista: ");
        int edicao = Convert.ToInt32(Console.ReadLine()!);

        Console.Write("Digite o Ano de Edição: ");
        int anoEdicao = Convert.ToInt32(Console.ReadLine()!);

        string statusEmprestimo = "Disponivel";

        Revista novaRevista = new Revista(titulo, edicao, anoEdicao, statusEmprestimo, caixaSelecionada);

        Console.WriteLine();
        Notificar.ExibirMensagem("Por padrão, o Status da Revista será Disponivel!", ConsoleColor.Yellow);

        return novaRevista;
    }

    public override void InserirRegistro()
    {
        ExibirCabecalho();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Cadastrando Revista.");
        Console.WriteLine("------------------------------------------\n");

        List<Caixa> caixas = repositorioCaixa.SelecionarTodos();

        if (caixas.Count == 0)
        {
            Notificar.ExibirMensagem("Você precisa Cadastrar uma caixa antes de Inserir uma nova Revista!", ConsoleColor.Red);
            return;
        }

        Revista novaRevista = (Revista)ObterDados();

        string ehValido = novaRevista.Validar();

        if (ehValido.Length > 0)
        {
            Notificar.ExibirMensagem(ehValido, ConsoleColor.Red);
            InserirRegistro();
            return;
        }

        foreach (Revista revista in repositorioRevista.SelecionarTodos())
        {
            if (revista.Titulo.Equals(novaRevista.Titulo))
            {
                Notificar.ExibirMensagem("Erro! Já existe uma revista cadastrada com o mesmo Título.", ConsoleColor.Red);
                return;
            }
            if (revista.Edicao.Equals(novaRevista.Edicao))
            {
                Notificar.ExibirMensagem("Erro! Já existe uma revista cadastrada com a mesma Edição.", ConsoleColor.Red);
                return;
            }
        }

        Caixa caixaSelecionada = novaRevista.Caixa;

        caixaSelecionada.AdicionarRevista(novaRevista);

        repositorioRevista.CadastrarRegistro(novaRevista);

        Notificar.ExibirMensagem($"Cadastro de Revista realizado com sucesso!", ConsoleColor.Green);
    }

    public override void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Editando Revista.");
        Console.WriteLine("------------------------------------------\n");

        VisualizarRegistros();

        Console.Write("Selecione o Id da Revista que deseja Editar: ");
        int idRevista = Convert.ToInt32(Console.ReadLine());

        Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarRegistroPorId(idRevista);

        Revista revistaEditada = ObterDados();

        string ehvalido = revistaEditada.Validar();

        if (ehvalido.Length > 0)
        {
            Notificar.ExibirMensagem(ehvalido, ConsoleColor.Red);

            return;
        }

        bool editou = repositorioRevista.EditarRegistro(idRevista, revistaEditada);

        if (!editou)
        {
            Notificar.ExibirMensagem("Erro! Não foi possivel editar esse registro.", ConsoleColor.Red);

            return;
        }

        Notificar.ExibirMensagem("Registro Editado com sucessao!", ConsoleColor.Green);
    }

    public override void ExcluirRegistro()
    {
        ExibirCabecalho();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Excluindo Revista.");
        Console.WriteLine("------------------------------------------\n");

        if (repositorioRevista.SelecionarTodos().Count == 0)
        {
            Notificar.ExibirMensagem("Não há revistas cadastradas para excluir!", ConsoleColor.Red);
            return;
        }

        VisualizarRegistros();

        Console.Write("Digite o ID da Revista que deseja excluir: ");
        int id = Convert.ToInt32(Console.ReadLine()!);

        Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarRegistroPorId(id);

        string podeExcluir = revistaSelecionada.Validar();

        if (podeExcluir.Length > 0)
        {
            Notificar.ExibirMensagem(podeExcluir, ConsoleColor.Red);
            return;
        }

        if (revistaSelecionada.StatusEmprestimo.Equals("Reservada"))
        {
            Console.Write("Esta revista foi reservada, deseja confirmar a exclusão dela? S/N: ");
            char opcao = Convert.ToChar(Console.ReadLine()!.ToUpper());

            if (opcao == 'N')
            {
                Notificar.ExibirMensagem("Exclusão cancelada pelo usuário.", ConsoleColor.Yellow);
                return;
            }
        }

        bool excluiu = repositorioRevista.ExcluirRegistro(id);

        if (!excluiu)
        {
            Notificar.ExibirMensagem($"Erro! Não foi possível excluir a Revista com ID {id}.", ConsoleColor.Red);
            return;
        }

        revistaSelecionada.Caixa.RemoverRevista(revistaSelecionada);

        Notificar.ExibirMensagem($"Revista {revistaSelecionada.Titulo} excluída com sucesso!", ConsoleColor.Green);
    }

    public override void VisualizarRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Visualizando Revistas.");
        Console.WriteLine("------------------------------------------\n");

        Console.WriteLine("{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -15}", "ID", "Título", "Ano Edição", "Edição", "Status");

        List<Revista> registros = repositorioRevista.SelecionarTodos();

        foreach (var revista in registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -15}",
                revista.Id, revista.Titulo, revista.AnoPublicacao, revista.Edicao, revista.StatusEmprestimo
                );
        }

        Console.WriteLine();
        Notificar.ExibirMensagem("Pressione [Enter] para continuar", ConsoleColor.Yellow);
    }
}
