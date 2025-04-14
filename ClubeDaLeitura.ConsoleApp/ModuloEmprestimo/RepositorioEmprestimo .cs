using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
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

    public void Editar() { }
    public void Excluir() { }
    public void SelecionarTodos() { }
    public void SelecionarPorId() { }

}

