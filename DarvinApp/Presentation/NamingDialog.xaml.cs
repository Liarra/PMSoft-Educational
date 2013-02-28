using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace DarvinApp.Presentation
{
    public partial class NamingDialog
    {
        public NamingDialog(IMessenger messenger)
        {
            if (messenger == null)
                throw new ArgumentNullException("messenger");
            InitializeComponent();
            messenger.Register<NotificationMessage>(this, NotificationMessageReceived);
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