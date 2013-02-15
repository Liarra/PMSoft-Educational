using System.Windows;
using DarvinApp.Business.DataTypes;
using DarvinApp.DataAccess.Hardcode;
using DarvinApp.Presentation;

namespace DarvinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow{ DataContext = new ViewModel(new HardcodeQuestionRepository()){CurrentQuestion = new Question("Nyananananana")} };
            window.Show();
        }
    }
}
