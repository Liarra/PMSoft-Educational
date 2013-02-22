using System.Windows;
using DarvinApp.Business.DataTypes;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace DarvinApp.Presentation
{
    public partial class NamingDialog
    {
        public NamingDialog(object token)
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if(msg.Notification=="ShowDialog")
            ShowDialog();
        }
    }
    
}