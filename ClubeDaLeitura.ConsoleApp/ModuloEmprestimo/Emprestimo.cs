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


    public bool Validar()
    {


        return true;
    }

    public void ObterDataDevolucao() { }

    public void RegistrarDevolucao() { }
}

    // Campos obrigatórios:
    //○ Amigo
    //○ Revista (disponível no momento)
    //○ Data empréstimo (automática)
    //○ Data devolução (calculada conforme caixa)
    //● Status possíveis: Aberto / Concluído / Atrasado
    //● Cada amigo só pode ter um empréstimo ativo por vez
    //● Empréstimos atrasados devem ser destacados visualmente
    //● A data de devolução é calculada automaticamente (data empréstimo + dias da
    //caixa)