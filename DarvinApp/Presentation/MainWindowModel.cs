using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows;
using System.Windows.Input;
using DarvinApp.Business;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DarvinApp.Presentation
{
    public class MainWindowModel : ViewModelBase
    {
        private int _questionListIndex;
        private readonly IExpert _expert;
        private readonly NamingDialog _namingDialog;
        private readonly IAnimalRepository _animalRepository;
        private readonly ResourceManager _animalTypeNames;
        private readonly IList<Question> _availableQuestions;

        private ICommand _yesButtonPushed;
        private ICommand _noButtonPushed;

        public Question CurrentQuestion
        {
            get { return _availableQuestions[_questionListIndex]; }
        }

        public MainWindowModel(IQuestionRepository questionsSource, IAnimalRepository animalSavingDestination,
                               IExpert expert, ResourceManager animalTypeNames)
        {
            if (questionsSource == null)
                throw new ArgumentNullException("questionsSource");
            if (animalSavingDestination == null)
                throw new ArgumentNullException("animalSavingDestination");
            if (expert == null)
                throw new ArgumentNullException("expert");
            if (animalTypeNames==null)
                throw new ArgumentNullException("animalTypeNames");
            if(!animalTypeDictionaryContainsAllSupportedTypes(expert,animalTypeNames))
                throw new ArgumentException("One or more animal types supported by the expert missing in resourse");
            _questionListIndex = 0;
            _expert = expert;
            _animalRepository = animalSavingDestination;
            _animalTypeNames = animalTypeNames;
            _availableQuestions = questionsSource.GetAllQuestions();

            _namingDialog = new NamingDialog();
        }

        private bool animalTypeDictionaryContainsAllSupportedTypes(IExpert expert, ResourceManager animalTypeNames)
        {
            IList<AnimalType> types = expert.SupportedTypes;
            return types.All(t => animalTypeNames.GetObject(t.ToString()) != null);
        }

        public ICommand YesButtonPushed
        {
            get
            {
                return _yesButtonPushed ??
                       (_yesButtonPushed = new RelayCommand(() =>
                           {
                               if (_availableQuestions.Count == 0) return;
                               _expert.SubmitAnswer(CurrentQuestion, true);
                               SelectNextQuestion();
                           }));
            }
        }

        public ICommand NoButtonPushed
        {
            get
            {
                return _noButtonPushed ?? (_noButtonPushed = new RelayCommand(() =>
                    {
                        if (_availableQuestions.Count == 0) return;
                        _expert.SubmitAnswer(CurrentQuestion, false);
                        SelectNextQuestion();
                    }));
            }
        }


        private void SelectNextQuestion()
        {
            if (_expert.ReadyToDecide())
            {
                ShowResultDialog();
                return;
            }

            if (_questionListIndex == _availableQuestions.Count - 1)
            {
                ShowResultDialog();
                return;
            }
            _questionListIndex++;
            RaisePropertyChanged(() => CurrentQuestion);
        }

        private void ShowResultDialog()
        {
            var animalType = _expert.Decision();
            var animalTypeName = _animalTypeNames.GetString(animalType.ToString());

            _namingDialog.TypeLabel.Content = animalTypeName;
            _namingDialog.Closed += (sender, e) => Application.Current.Shutdown(0);
            _namingDialog.SaveAnimalButton.Command = new RelayCommand(() =>
                {
                    var animalName = _namingDialog.AnimalNameBox.Text;
                    _animalRepository.WriteNewAnimal(new Animal {Name = animalName, Type = animalType});
                    MessageBox.Show("Животное сохранено");
                    Application.Current.Shutdown(0);
                });

            _namingDialog.ShowDialog();
        }
    }
}