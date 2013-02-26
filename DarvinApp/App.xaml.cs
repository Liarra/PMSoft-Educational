﻿using System.Resources;
using System.Windows;
using DarvinApp.Business;
using DarvinApp.DataAccess.Hardcode;
using DarvinApp.DataAccess.JSON;
using DarvinApp.Presentation;
using GalaSoft.MvvmLight.Messaging;

namespace DarvinApp
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            const int namingCallToken = 42;
            var window = new MainWindow
                {
                    DataContext =
                        new MainWindowModel(new HardcodeQuestionRepository(), new Expert(), namingCallToken, Messenger.Default)
                };

            window.Closed += (u, source) => Current.Shutdown(0);
            window.Show();

            var namingDialog = new NamingDialog
                {
                    DataContext =
                        new NamingDialogModel(new JsonAnimalRepository("AnimalTypes.txt"), namingCallToken,
                                              new ResourceManager(typeof (AnimalTypeReadableNames_RU)), Messenger.Default)
                };
            namingDialog.Closed += (sender, u) => Current.Shutdown(0);
        }
    }
}