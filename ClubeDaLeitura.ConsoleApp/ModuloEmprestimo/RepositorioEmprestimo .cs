using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class RepositorioEmprestimo
{
    public Emprestimo[] vetorEmprestimos = new Emprestimo[100];
    public int contEmprestimo = 0;

    public void Inserir(Emprestimo emprestimo)
    {
        vetorEmprestimos[contEmprestimo] = emprestimo;

        GeradorDeId.GerarIdEmprestimo();
    }

    public bool Editar(int idEmprestimo, Emprestimo emprestimo)
    {
        for (int i = 0; i < vetorEmprestimos.Length; i++)
        {
            if (vetorEmprestimos[i] == null)
                continue;

            if (vetorEmprestimos[i].IdEmprestimo == idEmprestimo)
            {
                vetorEmprestimos[i].IdEmprestimo = emprestimo.IdEmprestimo;
                vetorEmprestimos[i].AmigoEmp = emprestimo.AmigoEmp; 
                vetorEmprestimos[i].Situacao = emprestimo.Situacao;
                vetorEmprestimos[i].RevistaEmp = emprestimo.RevistaEmp;

                return true;
            }
        }

        return false;
    }
    public void Excluir() { }
    public void SelecionarTodos() { }
    public Emprestimo SelecionarPorId(int idEmp)
    {
        for (int i = 0; i < vetorEmprestimos.Length; i++)
        {
            Emprestimo obterEmp = vetorEmprestimos[i];
            if (obterEmp == null) continue;

            else if (obterEmp.IdEmprestimo == idEmp)
                return obterEmp;
        }

        return null;
    }

}

