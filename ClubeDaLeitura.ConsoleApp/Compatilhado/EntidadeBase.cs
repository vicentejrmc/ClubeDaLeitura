using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compatilhado;

public abstract class EntidadeBase
{
    public int Id { get; set; }

    public abstract string Validar();

    public abstract void AtualizarRegistro(EntidadeBase resgitroEditado);  // Inportará metodo filho
}
