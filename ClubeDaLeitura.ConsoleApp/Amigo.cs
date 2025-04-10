namespace ClubeDaLeitura.ConsoleApp;

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

    public string ValidarEntradas()
    { 
        string resultadoValidacao = "";

        if(string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3 || Nome.Length > 100)
            resultadoValidacao += "!...O campo nome não pode ser vazio, e deve ter entre 3 e 100 caracteres...!\n";

        if (string.IsNullOrWhiteSpace(Responsavel) || Responsavel.Length < 3 || Responsavel.Length > 100)
            resultadoValidacao += "!...O campo Responsável não pode ser vazio, e deve ter entre 3 e 100 caracteres...!\n";

        if (string.IsNullOrWhiteSpace(Telefone) || Telefone.Length < 10 || Telefone.Length > 12)
            resultadoValidacao += "!...O campo Telefone não pode ser vazio, e deve ter entre 10 e 15 caracteres...!\n";

        return resultadoValidacao;
    }
}
