using System.Windows;
using DarvinApp.Business;
using DarvinApp.DataAccess.Hardcode;
using DarvinApp.DataAccess.JSON;
using DarvinApp.Presentation;

namespace DarvinApp
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow
                {
                    DataContext =
                        new MainWindowModel(new HardcodeQuestionRepository(),
                                            new JsonAnimalRepository("AnimalTypes.txt"), new Expert())
                };

            window.Show();
        }
    }
}