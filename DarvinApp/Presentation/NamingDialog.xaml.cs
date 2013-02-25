using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace DarvinApp.Presentation
{
    public partial class NamingDialog
    {
        public NamingDialog()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ShowDialog")
                ShowDialog();
            if (msg.Notification == "NotifyAnimalSavedAndShutdownAlready")
            {
                MessageBox.Show("Животное сохранено");
                Application.Current.Shutdown(0);
            }
        }
    }
}