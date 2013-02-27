using System;
using System.Resources;
using System.Windows.Input;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace DarvinApp.Presentation
{
    public class NamingDialogModel : ViewModelBase
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ResourceManager _animalTypeNames;
        private AnimalType _animalType;
        private ICommand _saveAnimal;
        private readonly IMessenger _messenger;


        public NamingDialogModel(IAnimalRepository animalSavingDestination, object token,
                                 ResourceManager animalTypeNames, IMessenger messenger)
        {
            if (animalTypeNames == null)
                throw new ArgumentNullException("animalTypeNames");
            if (animalSavingDestination == null)
                throw new ArgumentNullException("animalSavingDestination");
            if (messenger == null)
                throw new ArgumentNullException("messenger");

            _animalRepository = animalSavingDestination;
            _animalTypeNames = animalTypeNames;
            _messenger = messenger;

            Messenger.Default.Register<NotificationMessage>(this, token, NotificationMessageReceived);
        }

        public string AnimalTypeName
        {
            get
            {
                var animalType = _animalType.ToString();
                return _animalTypeNames.GetString(animalType);
            }
        }

        public string AnimalName { get; set; }

        public ICommand AnimalSavingCommand
        {
            get
            {
                return _saveAnimal ??
                       (_saveAnimal = new RelayCommand(SaveAnimal));
            }
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            SetupDialog(msg.Notification);
        }

        private void SetupDialog(string animalType)
        {
            _animalType = (AnimalType) Enum.Parse(typeof (AnimalType), animalType);
            RaisePropertyChanged(() => AnimalTypeName);
        }

        private void SaveAnimal()
        {
            _animalRepository.WriteNewAnimal(new Animal {Name = AnimalName, Type = _animalType});
            _messenger.Send(new NotificationMessage("NotifyAnimalSavedAndShutdownAlready"));
        }
    }
}