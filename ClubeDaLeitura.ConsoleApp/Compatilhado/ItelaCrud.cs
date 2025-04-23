namespace ClubeDaLeitura.ConsoleApp.Compatilhado;

public interface ItelaCrud
{
    void InserirRegistro();
    void VisualizarRegistros();
    void EditarRegistro();
    void ExcluirRegistro();
    char ApresentarMenu();
}
