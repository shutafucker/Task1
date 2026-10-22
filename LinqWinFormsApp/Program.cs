namespace LinqWinFormsApp;

static class Program
{
    /// <summary>
    ///  Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormMain());
    }    
}
