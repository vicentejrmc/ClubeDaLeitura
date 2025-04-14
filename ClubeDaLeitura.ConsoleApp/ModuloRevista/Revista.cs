using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;

public class Revista
{
    public Caixa caixa = new Caixa("", "", 0);
    public RepositorioRevista repoRevista = new RepositorioRevista();
    public RepositorioAmigo amigo = new RepositorioAmigo();

    public int IdRevista;
    public string TituloRevista;
    public int NumEdicao;
    public int AnoEdicao;  
    public string StatusEmprestimo;
    public Caixa CaixaAtual;

    public Revista(string titulo, int numEdicao, int anoEdicao, string status, Caixa caixa)
    {
        TituloRevista = titulo;
        NumEdicao = numEdicao;
        AnoEdicao = anoEdicao;
        StatusEmprestimo = status;
        CaixaAtual = caixa;
    }

    //● Não pode haver revistas com mesmo título e edição - Refatorar
    //● Status possíveis: Disponível / Emprestada / Reservada  - Refatorar
    //● Ao cadastrar, o status padrão é "Disponível" - Refatorar para Int 0 1 2 

    public string ValidarRevista()
    {
        string resultadoValidacao = "";

        if (string.IsNullOrWhiteSpace(TituloRevista))
            resultadoValidacao += "...O Titulo não foi preenchido...!";

        if (TituloRevista.Length < 2 || TituloRevista.Length > 100)
            resultadoValidacao += "!...O Titulo precisa ter entre 2 e 100 Caracteres...!";

        if (NumEdicao < 1)
            resultadoValidacao += "!...O numero de Edição não pode ser menor que 0 ou Negativo...!";

        if (AnoEdicao > 2026) // refatorar Validação
            resultadoValidacao += "!...A menos que você seja um visitante do Futuro, essa data não é válida...!";

        if (CaixaAtual == null)
            resultadoValidacao += "!...Você precisa Selecionar uma caixa. O campo caixa não pode ficar vazio...!";

        // Validação para resvistas duplicadas

        return resultadoValidacao;
    }

    public void EmprestarRevista(int idRevista)
    {
       for (int i = 0; i < repoRevista.vetorRevista.Length; i++)
        {
            if (repoRevista.vetorRevista[i] == null) continue;

            else if(idRevista == repoRevista.vetorRevista[i].IdRevista)
            {
                repoRevista.vetorRevista[i].StatusEmprestimo = "Emprestada";
            }
        }
    }

    public void DevolverRevista() { }

    public void ReservarRevista() { }



}
