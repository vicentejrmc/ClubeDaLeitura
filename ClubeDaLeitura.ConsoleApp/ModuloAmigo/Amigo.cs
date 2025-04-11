using ClubeDaLeitura.ConsoleApp.Compatilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class Amigo
{
    public string Nome;
    public string Responsavel;
    public string Telefone;
    public int Id;

    public Amigo(string nome, string responsavel, string telefone)
    {
        Nome = nome;
        Responsavel = responsavel;
        Telefone = telefone;
        Id = GeradorDeId.GerarIdAmigo();
    }

    public string GerarIdAmigo()
    {
        return Id.ToString();
    }

    public string ValidarEntradas()
    { 
        string resultadoValidacao = "";

        if(string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3 || Nome.Length > 100)
            resultadoValidacao += "!...O campo nome não pode ser vazio, e deve ter entre 3 e 100 caracteres...!\n";

        if (string.IsNullOrWhiteSpace(Responsavel) || Responsavel.Length < 3 || Responsavel.Length > 100)
            resultadoValidacao += "!...O campo Responsável não pode ser vazio, e deve ter entre 3 e 100 caracteres...!\n";

        if (string.IsNullOrWhiteSpace(Telefone) || Telefone.Length < 10 || Telefone.Length > 15)
            resultadoValidacao += "!...O campo Telefone não pode ser vazio, e deve ter entre 10 e 15 caracteres...! Ex:(XX XXXX XXXX)\n";

        return resultadoValidacao;
    }

    //public string ValidarAmigoExiste(string nome, string responsavel, string telefone)
    //{
    //    string amigoExiste = "";
    //    for (int i = 0; i < vetorDeAmigos.Length; i++)
    //    {
    //        if (vetorDeAmigos[i].Nome == nome)
    //        {
    //            amigoExiste += "!...Já existe um amigo cadastrado com esse NOME...!\n";
    //        }

    //        if (vetorDeAmigos[i].Telefone == telefone)
    //        {
    //            amigoExiste += "!...!...Já existe um amigo cadastrado com esse TELEFONE...!\n";
    //        }
    //    }

    //    return amigoExiste;
    //}

}
