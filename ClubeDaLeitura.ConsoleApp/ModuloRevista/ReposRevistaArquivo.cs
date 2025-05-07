using ClubeDaLeitura.ConsoleApp.Compatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class ReposRevistaArquivo : ReposBaseArquivo<Revista>, IRepositorioRevista
    {
        protected override List<Revista> ObterRegistros()
        {
            return new List<Revista>();
        }
    }
}
