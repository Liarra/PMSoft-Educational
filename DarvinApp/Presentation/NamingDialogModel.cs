using System;
using System.Resources;
using System.Windows;
using System.Windows.Input;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace DarvinApp.Presentation
{
    public class NamingDialogModel:ViewModelBase
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ResourceManager _animalTypeNames;
        private AnimalType _animalType;
        private ICommand _saveAnimal;
        

        public NamingDialogModel(IAnimalRepository animalSavingDestination, object token, ResourceManager animalTypeNames)
        {
            if (animalTypeNames == null)
                throw new ArgumentNullException("animalTypeNames");
            if (animalSavingDestination == null)
                throw new ArgumentNullException("animalSavingDestination");

            _animalRepository = animalSavingDestination;
            _animalTypeNames = animalTypeNames;

            Messenger.Default.Register<NotificationMessage>(this, token, NotificationMessageReceived);
        }

        public string AnimalTypeName { get; set; }
        public string AnimalName { get; set; }
        public ICommand AnimalSavingCommand
        {
            get
            {
                return _saveAnimal ??
                (_saveAnimal=new RelayCommand(SaveAnimal));
            }
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            SetupDialog(msg.Notification);
        }

        private void SetupDialog(string animalType)
        {
            _animalType = (AnimalType) Enum.Parse(typeof (AnimalType), animalType);
            var animalTypeName = _animalTypeNames.GetString(animalType);
            AnimalTypeName = animalTypeName;
            RaisePropertyChanged(()=>AnimalTypeName);
        }

        private void SaveAnimal()
        {
            var animalName = AnimalName;
            _animalRepository.WriteNewAnimal(new Animal(animalName, _animalType));
            MessageBox.Show("Животное сохранено");
            Application.Current.Shutdown(0);
            
        }
    }
}