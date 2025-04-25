using ClubeDaLeitura.ConsoleApp.Compatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

//Criar metodo interno validar Emprestimo de revista dado seu status "emprestada" ou "disponivel" ou "Reservada"

public class TelaRevista : TelaBase<Revista>, ItelaCrud
{
    public RepositorioRevista repositorioRevista;

    public TelaRevista(RepositorioRevista repositorioRevista) : base("Revista", repositorioRevista) // construtor de Tela para TelaRevista
    {
        this.repositorioRevista = repositorioRevista;
    }

    public override Revista ObterDados()
    {
        throw new NotImplementedException();
    }

    public override void VisualizarRegistros()
    {
        throw new NotImplementedException();
    }
}
