using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Util;
using System.Reflection.Metadata.Ecma335;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class Caixa : EntidadeBase<Caixa>
{
    public string Etiqueta{ get; set; }
    public string Cor { get; set; }
    public int DiasEmprestimo { get; set; }
    public Revista[] Revistas { get; set; }

    public int QtdRevistas
    {
        get
        {
            int cont = 0;
            for (int i = 0; i < Revistas.Length; i++)
            {
                if (Revistas[i] != null)
                    cont++;
            }
            return cont;
        }
    }

    public Caixa()
    {
    }

    public Caixa(string etiqueta, string cor, int diasEmprestimo)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        DiasEmprestimo = diasEmprestimo;
        Revistas = new Revista[100];
    }

    public override void AtualizarRegistro(Caixa caixaEditada)
    {
        Etiqueta = caixaEditada.Etiqueta;
        Cor = caixaEditada.Cor;
        DiasEmprestimo = caixaEditada.DiasEmprestimo;
    }

    public override string Validar()
    {
        string errosValidacao = "";

        if (String.IsNullOrWhiteSpace(Etiqueta))
            errosValidacao += "Erro! A etiqueta não pode ser vazia, ou conter espaços em branco.\n";

        if (Etiqueta.Length < 3 || Etiqueta.Length > 50)
            errosValidacao += "Erro! A etiqueta deve ter entre 3 e 50 caracteres.\n";

        if (String.IsNullOrWhiteSpace(Cor))
            errosValidacao += "Erro! A cor não pode ser vazia.\n";

        return errosValidacao;
    }

    public void AdicionarRevista(Revista revista)
    {
        for (int i = 0; i < Revistas.Length; i++)
        {
            if (Revistas[i] == null)
            {
                Revistas[i] = revista;
                break;
            }
        }

    }
    public void RemoverRevista(Revista revista)
    {
        for (int i = 0; i < Revistas.Length; i++)
        {
            if (Revistas[i] == revista)
            {
                Revistas[i] = null;
                return;
            }
        }
    }

   
}