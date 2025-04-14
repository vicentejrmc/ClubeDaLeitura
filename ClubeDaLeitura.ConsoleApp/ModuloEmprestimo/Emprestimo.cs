using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class Emprestimo
{
    public int IdEmprestimo;
    public Amigo AmigoEmp;
    public Revista RevistaEmp;
    public DateTime Data;
    public string Situacao;

    public Emprestimo(Revista revista, string status, DateTime data, Amigo amigo)
    {
        RevistaEmp = revista;
        Situacao = status;
        Data = data;
        AmigoEmp = amigo;
    }
    // Campos obrigatórios:

    //● Status possíveis: Aberto / Concluído / Atrasado
    //● Cada amigo só pode ter um empréstimo ativo por vez
    //● Empréstimos atrasados devem ser destacados visualmente
    //● A data de devolução é calculada automaticamente (data empréstimo + dias da
    //caixa)

    public string Validar(Emprestimo novo)
    {
        string invalidado = " ";

        if (string.IsNullOrWhiteSpace(novo.AmigoEmp.Nome) == null)
            invalidado += "O Campo Amigo é Obrigatorio!";

        if(novo.RevistaEmp.StatusEmprestimo == "Emprestada")
            invalidado += "Essa Revista está Indisponível no Momento!";

        return invalidado;
    }

    public void ObterDataDevolucao() { }

    public void RegistrarDevolucao()
    {   
    }
}

    