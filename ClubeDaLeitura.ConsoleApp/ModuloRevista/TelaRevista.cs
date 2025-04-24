using ClubeDaLeitura.ConsoleApp.Compatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class TelaRevista : TelaBase<Revista>, ItelaCrud
{
    public override Revista ObterDados()
    {
        throw new NotImplementedException();
    }

    public override void VisualizarRegistros()
    {
        throw new NotImplementedException();
    }
}
