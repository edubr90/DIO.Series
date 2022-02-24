namespace DIO.Series.Interfaces.Command
{
    public interface ICommand
    {
        bool GetAllSeries();
        bool CreateSerie();
        bool UpdateSerie();
        bool DeleteSerie();
        bool ViewSerie();
        bool ClearConsole();
        bool ExitSystem();
    }
}