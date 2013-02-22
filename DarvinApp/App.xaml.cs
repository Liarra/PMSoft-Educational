using System.Resources;
using System.Windows;
using DarvinApp.Business;
using DarvinApp.DataAccess.Hardcode;
using DarvinApp.DataAccess.JSON;
using DarvinApp.Presentation;

namespace DarvinApp
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow
                {
                    DataContext =
                        new MainWindowModel(new HardcodeQuestionRepository(),
                                            new JsonAnimalRepository("AnimalTypes.txt"), new Expert(),
                                            new ResourceManager(typeof (AnimalTypeReadableNames_RU)))
                };
            window.Closed += (u, source) => Current.Shutdown(0);
            window.Show();
        }
    }
}