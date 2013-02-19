using System;
using System.Collections.Generic;
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
        public IList<Question> AvailableQuestions { get; set; }

        public IExpert Expert { get; set; }

        private ICommand _yesButtonPushed, _noButtonPushed;
        private NamingDialog _namingDialog;

        private readonly IAnimalRepository _animalRepository;

        public Question CurrentQuestion
        {
            get { return AvailableQuestions[_questionListIndex]; }
        }

        public NamingDialog NamingDialog
        {
            get { return _namingDialog ?? (_namingDialog = new NamingDialog()); }
            set { _namingDialog = value; }
        }

        public MainWindowModel(IQuestionRepository questionsSource, IAnimalRepository animalSavingDestination,
                               IExpert expert)
        {
            _questionListIndex = 0;

            if (expert == null)
                throw new NullReferenceException("It's impossible to create expert system model without IExpert");
            Expert = expert;

            _animalRepository = animalSavingDestination;

            if (questionsSource == null)
                throw new NullReferenceException(
                    "It's impossible to create expert system model without IQuestionRepository");
            AvailableQuestions = questionsSource.GetAllQuestions();
        }

        public ICommand YesButtonPushed
        {
            get
            {
                return _yesButtonPushed ??
                       (_yesButtonPushed = new RelayCommand(() =>
                           {
                               if (AvailableQuestions.Count == 0) return;
                               Expert.SubmitAnswer(CurrentQuestion, true);
                               SelectNextQuestion();
                           }));
            }
        }

        public ICommand NoButtonPushed
        {
            get
            {
                return _noButtonPushed ??
                       (_noButtonPushed = new RelayCommand(() =>
                           {
                               if (AvailableQuestions.Count == 0) return;
                               Expert.SubmitAnswer(CurrentQuestion, false);
                               SelectNextQuestion();
                           }
                                              ));
            }
        }


        private void SelectNextQuestion()
        {
            if (Expert.ReadyToDecide())
            {
                ShowResultDialog();
                return;
            }

            if (_questionListIndex == AvailableQuestions.Count-1)
            {
                ShowResultDialog();
                return;
            }
            _questionListIndex++;
            RaisePropertyChanged(() => CurrentQuestion);
        }

        private void ShowResultDialog()
        {
            NamingDialog.TypeLabel.Content = Expert.DecisionString();
            NamingDialog.SaveAnimalButton.Command = new RelayCommand(() =>
                {
                    AnimalType animalType = Expert.Decision();
                    string animalName = NamingDialog.AnimalNameBox.Text;

                    _animalRepository.WriteNewAnimal(animalName, animalType);
                    MessageBox.Show("Животное сохранено");
                    Application.Current.Shutdown(0);
                });
            NamingDialog.ShowDialog();
        }
    }
}